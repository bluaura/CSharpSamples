﻿using CSharpSamples;
using System;
using System.IO;

class Program
{
    static void Main()
    {
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
        FileWatcherProdConsThread.startWatching();
    }
}
