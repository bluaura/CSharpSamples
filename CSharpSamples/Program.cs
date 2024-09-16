using CSharpSamples;
using System;
using System.IO;

class Program
{
    // 전역 Mutex 선언
    static Mutex mutex = null;

    static void Main()
    {
        const string mutexName = "Global\\MyTestProgram";  // Mutex 이름 설정 (전역으로 사용하기 위해 "Global\\" 접두사 추가)

        // 뮤텍스를 얻으려고 시도함
        bool isNewInstance;
        mutex = new Mutex(true, mutexName, out isNewInstance);

        if (!isNewInstance)
        {
            Console.WriteLine("프로그램이 이미 실행 중입니다.");
            return;
        }

        try
        {
            // 프로그램의 주 로직 실행
            Console.WriteLine("프로그램 실행 중...");
            ProcessExecuteWrpperClass.Run();
            Console.ReadLine();  // 프로그램 유지
        }
        finally
        {
            // 뮤텍스 해제
            if (mutex != null)
            {
                mutex.ReleaseMutex();
            }
        }


        /*
        Console.WriteLine("StreamWriter Sample");
        StreamWriteSample.SteamWriterSample1();

        Console.WriteLine("StreamReader Sample");
        StreamReaderSample.StreamReaderSample1();

        Console.WriteLine("TrimEnd sample");
        TrimEndSample.TrimEndSample1();

        Console.WriteLine("Hidden Directory Check");
        HiddenDirecotyCheckSample.HiddenDirectorySample1();

        Console.WriteLine("Hidden File Check");
        HiddenFileCheckSample.HiddenFileCheckSample1();

        TraverseFileSample.TraverseDirectory("C:\\Users\\c\\Downloads");

        Console.WriteLine("Traverse Directory Sample");
        TraverseDirectorySample.TraverseDirectory("C:\\");
        */

        //        PortGenerator.GetPort();
        //        Console.WriteLine("Producer Consumer Sample");
        //        ProdConsumerSample.ProducerConsumerSample();

        //        DirectoryOutExample.PrintDirectory("C:\\Windows");

        //        string drivePath = @"C:\"; // 탐색할 드라이브 경로

        // 숨김 폴더 및 파일 경로를 출력할 파일 경로를 설정합니다.


        // 숨김 폴더와 파일을 파일에 기록하는 함수를 호출합니다.
        //      HiddenFileAndDirectoryScan.WriteHiddenFoldersAndFilesToFile(drivePath);

        //        FileSystemWatcherExample.FileSystemWatcherFunction();
        //        ProducerConsumerFileWatcher.FileSystemWatcherExample();
        //        FileWatcherProdConsThread.startWatching();


    }
}
