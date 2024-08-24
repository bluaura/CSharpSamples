using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CSharpSamples
{
    class PortGenerator
    {
        public static int GetPort()
        {
            Random random = new Random();
            int port;

            do
            {
                // 1024에서 65535 사이의 랜덤 포트 번호 생성
                port = random.Next(1024, 65536);
                Console.WriteLine("generated port num : " + port);
            }
            while (!IsPortAvailable(port));

            Console.WriteLine("available port : " + port);

            return port;
        }

        private static bool IsPortAvailable(int port)
        {
            // 포트가 사용 중인지 확인
            bool isAvailable = true;

            try
            {
                // TcpListener를 사용해 해당 포트가 사용 가능한지 확인
                TcpListener listener = new TcpListener(System.Net.IPAddress.Any, port);
                listener.Start();
                listener.Stop();
            }
            catch (SocketException)
            {
                isAvailable = false; // 포트가 사용 중이면 false 반환
            }

            return isAvailable;
        }
    }
}
