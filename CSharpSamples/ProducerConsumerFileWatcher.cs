using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CSharpSamples
{
    class ProducerConsumerFileWatcher
    {
        private static readonly BlockingCollection<string> EventQueue = new BlockingCollection<string>();
        private static string[] ignoreDirectories = { @"C:\Windows", "C:\\ProgramData", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) };

        public static void FileSystemWatcherExample()
        {
            // Consumer Task 시작
            Task consumerTask = Task.Factory.StartNew(Consumer, TaskCreationOptions.LongRunning);

            // 모니터링할 드라이브 경로를 설정합니다.
//            string[] drivePaths = { @"C:\", @"D:\" };
            string[] drivePaths = { @"C:\" };

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

                Console.WriteLine($"Monitoring changes on drive: {drivePath}");
            }

            Console.WriteLine("Press 'q' to quit the application.");

            // 종료할 때까지 계속 실행
            while (Console.Read() != 'q') ;

            // 프로그램 종료 시 BlockingCollection 완료를 알림
            EventQueue.CompleteAdding();

            // Consumer Task가 종료될 때까지 대기
            consumerTask.Wait();
        }

        // Producer 역할: 이벤트가 발생하면 큐에 추가
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (IsIgnoreDirectories(e.FullPath)) return;

            string message = e.ChangeType switch
            {
                WatcherChangeTypes.Created => $"File created: {e.FullPath}",
                WatcherChangeTypes.Deleted => $"File deleted: {e.FullPath}",
                WatcherChangeTypes.Changed => $"File changed: {e.FullPath}",
                _ => null
            };

            if (message != null)
            {
                EventQueue.Add(message);
            }
        }

        // Producer 역할: 파일 이름이 변경될 때 큐에 추가
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            if (IsIgnoreDirectories(e.FullPath)) return;

            string message = $"File renamed from {e.OldFullPath} to {e.FullPath}";
            EventQueue.Add(message);
        }

        // Consumer 역할: 큐에서 이벤트를 꺼내어 처리
        private static void Consumer()
        {
            foreach (var message in EventQueue.GetConsumingEnumerable())
            {
                Console.WriteLine(message);
            }
        }

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
