using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class StreamWriteSample
    {
        public static void SteamWriterSample1()
        {
            string filePath = "output.txt";

            // 파일에 한 줄씩 쓰기
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("첫 번째 줄입니다.");
                writer.WriteLine("두 번째 줄입니다.");
                writer.WriteLine("세 번째 줄입니다.");
            }

            Console.WriteLine("내용이 파일에 작성되었습니다.");
        }
    }
}
