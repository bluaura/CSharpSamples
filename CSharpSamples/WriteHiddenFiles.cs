using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class WriteHiddenFiles
    {
        public static void WriteHiddenFolders(string drivePath)
        {
            string outputPath = @"C:\Users\c\Documents\hidden_directory_list.txt"; // 출력할 파일 경로

            // 큐를 사용하여 디렉터리를 순회합니다.
            Queue<string> directories = new Queue<string>();
            directories.Enqueue(drivePath);

            using (StreamWriter writer = new StreamWriter(outputPath))
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
                                writer.WriteLine(subDirectory);
                            }

                            // 하위 디렉터리를 큐에 추가하여 순회합니다.
                            directories.Enqueue(subDirectory);
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Access denied to: " + currentDirectory);
                        // 접근이 거부된 경우 로그를 남길 수 있습니다.
                        //writer.WriteLine("Access denied to: " + currentDirectory);
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
        public static void WriteHiddenFilesAndFolders(string startPath)
        {
            Queue<string> directoriesQueue = new Queue<string>();
            directoriesQueue.Enqueue(startPath);
            string outputPath = @"C:\Users\c\Documents\hidden_files_list.txt"; // 출력할 파일 경로
            string directoryOutputPath = @"C:\Users\c\Documents\hidden_directory_list.txt"; // 출력할 파일 경로

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                using (StreamWriter directoryWriter = new StreamWriter(directoryOutputPath))
                {
                    while (directoriesQueue.Count > 0)
                    {
                        string currentDirectory = directoriesQueue.Dequeue();

                        try
                        {
                            // 현재 폴더의 하위 폴더를 가져옵니다.
                            string[] subDirectories = Directory.GetDirectories(currentDirectory);

                            foreach (string subDirectory in subDirectories)
                            {
                                // 숨김 속성이 설정된 폴더만 큐에 추가하고 파일에 기록합니다.
                                DirectoryInfo dirInfo = new DirectoryInfo(subDirectory);
                                if ((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                                {
                                    writer.WriteLine("Hidden Folder: " + subDirectory);
                                    directoriesQueue.Enqueue(subDirectory);
                                }
                            }

                            // 현재 폴더 내의 모든 파일을 가져옵니다.
                            string[] files = Directory.GetFiles(currentDirectory);

                            foreach (string file in files)
                            {
                                // 파일이 숨김 속성을 가지고 있는지 확인하고 기록합니다.
                                FileInfo fileInfo = new FileInfo(file);
                                if ((fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                                {
                                    writer.WriteLine("Hidden File: " + file);
                                }
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            Console.WriteLine("Access denied to: " + currentDirectory);
                            // 접근이 거부된 경우 로그를 남길 수 있습니다.
                            writer.WriteLine("Access denied to: " + currentDirectory);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error processing directory: " + currentDirectory);
                            Console.WriteLine(ex.Message);
                            // 기타 오류를 처리할 수 있습니다.
                        }
                    }
                }

                Console.WriteLine("Hidden folders and files have been written to " + outputPath);
            }
        }
    }
}
