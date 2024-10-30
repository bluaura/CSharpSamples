using CSharpSamples;
using System;
using System.IO;

class Program
{
    // Mutex 예제
    // 전역 Mutex 선언
    //
    // static Mutex mutex = null;

    static void Main()
    {
        /* Mutex 예제
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
        }*/


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

        /*
        List<string> oldList = new List<string> { "Apple", "Banana", "Orange" };
        List<string> newList = new List<string> { "Apple", "Banana", "Grape", "Mango" };

        CompareStringLists(oldList, newList);
        */

        // 파일 접근 권한 테스트
        Console.WriteLine("파일 접근 권한 테스트");
        string filePath = @"C:\\Users\\Default\\NTUSER.DAT";

        try
        {
            FileAccessTest.CheckFileAccess(filePath);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("파일에 접근할 권한이 없습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"오류 발생: {ex.Message}");
        }

        // 디렉토리 접근 권한 테스트
        Console.WriteLine("디렉토리 접근 권한 테스트");
        string directoryPath = @"C:\\Users\\Default";

        try
        {
            DirectoryAccessTest.CheckDirectoryAccess(directoryPath);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("디렉토리에 접근할 권한이 없습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"오류 발생: {ex.Message}");
        }

        // Junction Test
        Console.WriteLine("Junction Test");
        string juctionDirectoryPath = @"C:\\Users\\Default\\Cookies";

        if (JunctionTest.IsJunction(juctionDirectoryPath))
        {
            Console.WriteLine("이 디렉터리는 JUNCTION입니다.");
        }
        else
        {
            Console.WriteLine("이 디렉터리는 JUNCTION이 아닙니다.");
        }

        // 심볼릭 링크 테스트
        string symFilePath = @"C:\\Users\\c\\Links\\Downloads.lnk";

        if (SymbolicLinkTest.IsSymbolicLink(symFilePath))
        {
            Console.WriteLine("이 파일은 심볼릭 링크입니다.");
        }
        else
        {
            Console.WriteLine("이 파일은 심볼릭 링크가 아닙니다.");
        }
    }

    static void CompareStringLists(List<string> oldList, List<string> newList)
    {
        // 추가된 문자열
        var added = newList.Except(oldList).ToList();
        // 삭제된 문자열
        var removed = oldList.Except(newList).ToList();

        Console.WriteLine("added list count : " + added.Count);
        Console.WriteLine("removed list count : " + removed.Count);
        Console.WriteLine();

        Console.WriteLine("Added Strings:");
        foreach (var add in added)
        {
            Console.WriteLine(add);
        }

        Console.WriteLine("\nRemoved Strings:");
        foreach (var remove in removed)
        {
            Console.WriteLine(remove);
        }
    }
}
