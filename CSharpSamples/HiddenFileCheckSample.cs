using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class HiddenFileCheckSample
    {
        public static void HiddenFileCheckSample1()
        {
            string filePath = @"C:\Users\c\NTUSER.DAT"; // 확인할 파일 경로

            // FileInfo 객체 생성
            FileInfo fileInfo = new FileInfo(filePath);

            // 파일이 존재하는지 확인
            if (fileInfo.Exists)
            {
                // 숨겨진 파일인지 확인
                if ((fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    Console.WriteLine("파일은 숨겨진 상태입니다.");
                }
                else
                {
                    Console.WriteLine("파일은 숨겨져 있지 않습니다.");
                }
            }
            else
            {
                Console.WriteLine("파일이 존재하지 않습니다.");
            }
        }
    }
}
