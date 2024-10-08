﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class TraverseDirectorySample
    {
        public static void TraverseDirectory(string path)
        {
            string rootDirectory = @"C:\"; // 탐색할 루트 디렉터리 경로

            // 디렉터리 경로를 저장할 큐 생성
            Queue<string> directories = new Queue<string>();

            // 루트 디렉터리를 큐에 추가
            directories.Enqueue(rootDirectory);

            // 큐가 비어있지 않으면 반복
            while (directories.Count > 0)
            {
                // 큐에서 디렉터리를 꺼냄
                string currentDirectory = directories.Dequeue();

                try
                {
                    // 현재 디렉터리 출력 (숨겨진 디렉터리 제외)
                    DirectoryInfo dirInfo = new DirectoryInfo(currentDirectory);
                    if ((dirInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        Console.WriteLine(currentDirectory);
                    }

                    // 현재 디렉터리의 서브디렉터리들을 큐에 추가 (숨겨진 디렉터리 제외)
                    string[] subDirectories = Directory.GetDirectories(currentDirectory);
                    foreach (string subDirectory in subDirectories)
                    {
                        DirectoryInfo subDirInfo = new DirectoryInfo(subDirectory);

                        // 서브디렉터리가 숨겨진 디렉터리인지 확인
                        if ((subDirInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        {
                            directories.Enqueue(subDirectory);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // 권한이 없거나 액세스할 수 없는 디렉터리일 경우 처리
                    Console.WriteLine($"접근할 수 없는 디렉터리: {currentDirectory}");
                }
            }
        }
    }
}
