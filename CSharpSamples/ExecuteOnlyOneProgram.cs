using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class ExecuteOnlyOneProgram
    {    // 전역 Mutex 선언
        /*
        static Mutex mutex = null;

        static void Main(string[] args)
        {
            const string mutexName = "Global\\MyTestProgram";  // Mutex 이름 설정 (전역으로 사용하기 위해 "Global\\" 접두사 추가)

            // 뮤텍스를 얻으려고 시도함
            bool isNewInstance;
            mutex = new Mutex(true, mutexName, out isNewInstance);

            if (!isNewInstance)
            {
                Console.WriteLine("프로그램이 이미 실행 중입니다.");
                return;
            }

            try
            {
                // 프로그램의 주 로직 실행
                Console.WriteLine("프로그램 실행 중...");
                Console.ReadLine();  // 프로그램 유지
            }
            finally
            {
                // 뮤텍스 해제
                if (mutex != null)
                {
                    mutex.ReleaseMutex();
                }
            }
        }
        */
    }
}
