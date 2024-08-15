using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class HiddenDirecotyCheckSample
    {
        public static void HiddenDirectorySample1()
        {
            string directoryPath = @"C:\Users\c\AppData"; // 확인할 디렉터리 경로

            // DirectoryInfo 객체 생성
            DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

            // 디렉터리가 존재하는지 확인
            if (dirInfo.Exists)
            {
                // 숨겨진 디렉터리인지 확인
                if ((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    Console.WriteLine("디렉터리는 숨겨진 상태입니다.");
                }
                else
                {
                    Console.WriteLine("디렉터리는 숨겨져 있지 않습니다.");
                }
            }
            else
            {
                Console.WriteLine("디렉터리가 존재하지 않습니다.");
            }
        }
    }
}
