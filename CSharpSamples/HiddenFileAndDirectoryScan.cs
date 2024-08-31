using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class HiddenFileAndDirectoryScan
    {
        public static void WriteHiddenFoldersAndFilesToFile(string drivePath)
        {
            string outputDirectoryPath = @"C:\Users\c\Documents\hidden_directories.txt";
            string outputFilePath = @"C:\Users\c\Documents\hidden_files.txt";

            // 큐를 사용하여 디렉터리를 순회합니다.
            Queue<string> directories = new Queue<string>();
            directories.Enqueue(drivePath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamWriter directoryWriter = new StreamWriter(outputDirectoryPath))
                {
                    while (directories.Count > 0)
                    {
                        string currentDirectory = directories.Dequeue();

                        try
                        {
                            // 현재 디렉터리의 하위 디렉터리를 가져옵니다.
                            string[] subDirectories = Directory.GetDirectories(currentDirectory);

                            foreach (string subDirectory in subDirectories)
                            {
                                // 숨김 속성이 설정된 디렉터리만 큐에 추가하고 파일에 기록합니다.
                                DirectoryInfo dirInfo = new DirectoryInfo(subDirectory);
                                if ((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                                {
                                    directoryWriter.WriteLine(subDirectory);
                                }

                                // 하위 디렉터리를 큐에 추가하여 순회합니다.
                                directories.Enqueue(subDirectory);
                            }

                            // 현재 디렉터리 내의 모든 파일을 가져옵니다.
                            string[] files = Directory.GetFiles(currentDirectory);

                            foreach (string file in files)
                            {
                                // 파일이 숨김 속성을 가지고 있는지 확인하고 기록합니다.
                                FileInfo fileInfo = new FileInfo(file);
                                if ((fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                                {
                                    writer.WriteLine(file);
                                }
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("Access denied to: " + currentDirectory);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error processing directory: " + currentDirectory);
                            Console.WriteLine(ex.Message);
                            // 기타 오류를 처리할 수 있습니다.
                        }
                    }
                }
            }
        }
    }
}
