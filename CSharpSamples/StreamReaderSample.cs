using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class StreamReaderSample
    {
        public static void StreamReaderSample1()
        {
            string filePath = "output.txt";

            // 파일에서 한 줄씩 읽기
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("파일이 존재하지 않습니다.");
            }
        }
    }
}
