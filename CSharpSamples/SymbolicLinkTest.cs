using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class SymbolicLinkTest
    {
        public static bool IsSymbolicLink(string filePath)
        {
            if (!File.Exists(filePath) && !Directory.Exists(filePath))
            {
                throw new FileNotFoundException("파일 또는 디렉터리를 찾을 수 없습니다.");
            }

            // 파일 또는 디렉터리 속성 가져오기
            FileAttributes attributes = File.GetAttributes(filePath);

            // ReparsePoint 속성 확인 (심볼릭 링크는 ReparsePoint 속성을 가집니다)
            return (attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint;
        }
    }
}
