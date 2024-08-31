using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class FileSystemWatcherExample
    {
        private static readonly Dictionary<string, DateTime> LastProcessedEvent = new Dictionary<string, DateTime>();
        private static readonly object LockObject = new object();
        private const int EventDebounceTimeMs = 500; // 이벤트 디바운스 시간 (밀리초)
        private static string[] ignoreDirectories = { @"C:\Windows", "C:\\ProgramData", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) };

        public static void FileSystemWatcherFunction()
        {
            // 모니터링할 드라이브 경로를 설정합니다.
//            string[] drivePaths = { @"C:\", @"D:\" };
            string[] drivePaths = { @"C:\" };

            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();

            foreach (var drivePath in drivePaths)
            {
                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = drivePath,
                    IncludeSubdirectories = true, // 하위 디렉터리까지 포함하여 모니터링
                    InternalBufferSize = 64 * 1024, // 버퍼 크기를 64KB로 증가
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite,
                    Filter = "*.*"
                };

                // 이벤트 핸들러를 등록합니다.
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Changed += OnChanged;
                watcher.Renamed += OnRenamed;

                // 모니터링 시작
                watcher.EnableRaisingEvents = true;

                // watcher를 리스트에 추가하여 관리합니다.
                watchers.Add(watcher);

                Console.WriteLine($"Monitoring changes on drive: {drivePath}");
            }

            Console.WriteLine("Press 'q' to quit the application.");

            // 종료할 때까지 계속 실행
            while (Console.Read() != 'q') ;

            // 모든 watcher를 정리
            foreach (var watcher in watchers)
            {
                watcher.Dispose();
            }
        }

        // 변경, 생성, 삭제 이벤트가 발생할 때 호출되는 메서드
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            lock (LockObject)
            {
                if (IsDuplicateEvent(e.FullPath) || IsIgnoreDirectories(e.FullPath)) return;

                // 이벤트 유형에 따라 메시지를 출력합니다.
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Created:
                        Console.WriteLine($"File created: {e.FullPath}");
                        break;
                    case WatcherChangeTypes.Deleted:
                        Console.WriteLine($"File deleted: {e.FullPath}");
                        break;
                    case WatcherChangeTypes.Changed:
                        Console.WriteLine($"File changed: {e.FullPath}");
                        break;
                }
            }
        }

        // 파일이나 디렉터리 이름이 변경될 때 호출되는 메서드
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            lock (LockObject)
            {
                if (IsDuplicateEvent(e.FullPath) || IsIgnoreDirectories(e.FullPath)) return;

                Console.WriteLine($"File renamed from {e.OldFullPath} to {e.FullPath}");
            }
        }

        // 중복 이벤트를 방지하기 위한 메서드 (디바운싱 처리)
        private static bool IsDuplicateEvent(string filePath)
        {
            DateTime now = DateTime.Now;

            if (LastProcessedEvent.TryGetValue(filePath, out DateTime lastEventTime))
            {
                // 디바운스 시간 내에 발생한 중복 이벤트인지 확인
                if ((now - lastEventTime).TotalMilliseconds < EventDebounceTimeMs)
                {
                    return true; // 중복 이벤트이므로 무시
                }
            }

            // 마지막 이벤트 시간 갱신
            LastProcessedEvent[filePath] = now;
            return false;
        }

        // C:\Windows 디렉터리 내의 파일인지 확인하는 메서드
        private static bool IsIgnoreDirectories(string filePath)
        {
            foreach (string ignoreDirectory in ignoreDirectories)
            {
                if (filePath.StartsWith(ignoreDirectory, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
