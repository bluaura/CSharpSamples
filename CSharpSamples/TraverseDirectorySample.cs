using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class TraverseDirectorySample
    {
        public static void TraverseDirectory(string rootDir)
        {
            // 디렉터리 경로를 저장할 큐 생성
            Queue<string> directories = new Queue<string>();

            // 최상위 디렉터리를 큐에 추가
            directories.Enqueue(rootDir);

            // 큐가 비어있지 않으면 반복
            while (directories.Count > 0)
            {
                // 큐에서 디렉터리를 꺼냄
                string currentDirectory = directories.Dequeue();

                try
                {
                    // 현재 디렉터리의 모든 파일 출력 (숨겨진 파일 제외)
                    string[] files = Directory.GetFiles(currentDirectory);
                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);

                        // 파일이 숨겨진 파일인지 확인
                        if ((fileInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        {
                            Console.WriteLine(file);
                        }
                    }

                    // 현재 디렉터리의 서브디렉터리들을 큐에 추가 (숨겨진 디렉터리 제외)
                    string[] subDirectories = Directory.GetDirectories(currentDirectory);
                    foreach (string subDirectory in subDirectories)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(subDirectory);

                        // 서브디렉터리가 숨겨진 디렉터리인지 확인
                        if ((dirInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        {
                            directories.Enqueue(subDirectory);
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // 권한이 없거나 액세스할 수 없는 디렉터리일 경우 처리
                    Console.WriteLine($"접근할 수 없는 디렉터리: {currentDirectory}");
                }
            }
        }
    }
}
