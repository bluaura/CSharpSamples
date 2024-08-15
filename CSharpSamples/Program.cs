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
    }
}
