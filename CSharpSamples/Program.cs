using CSharpSamples;
using System;
using System.IO;

class Program
{
    static void Main()
    {
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

        TraverseDirectorySample.TraverseDirectory("C:\\Users\\c\\Downloads");
    }
}
