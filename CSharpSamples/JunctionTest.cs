using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class JunctionTest
    {
        public static bool IsJunction(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException("디렉터리를 찾을 수 없습니다.");
            }

            // 디렉터리 속성 가져오기
            FileAttributes attributes = File.GetAttributes(directoryPath);

            // ReparsePoint 속성 확인 (JUNCTION은 ReparsePoint 중 하나로 표시됩니다)
            return (attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint;
        }
    }
}
