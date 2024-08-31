using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class DirectoryOutExample
    {
        public static void PrintDirectory(string directoryPath)
        {
            // DirectoryInfo 객체 생성
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // 최근에 수정된 파일을 기준으로 정렬하고 파일 리스트를 가져옴
            var recentFiles = directoryInfo.GetFiles()
                                           .OrderByDescending(f => f.LastWriteTime)
                                           .Take(100); // 최근 수정된 파일 상위 10개 가져오기

            Console.WriteLine($"최근 수정된 파일 목록 (경로: {directoryPath}):");

            // 파일 리스트 출력
            foreach (var file in recentFiles)
            {
                Console.WriteLine($"{file.FullName} - 수정일: {file.LastWriteTime}");
            }
        }
    }
}
