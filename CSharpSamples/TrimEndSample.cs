using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class TrimEndSample
    {
        public static void TrimEndSample1()
        {
            string input = @"C:\example\path\";  // 예시 문자열

            // '\'로 끝나는 경우 '\'만 제거
            if (input.EndsWith("\\"))
            {
                input = input.TrimEnd('\\');
            }

            Console.WriteLine(input);  // 출력: C:\example\path
        }
    }
}
