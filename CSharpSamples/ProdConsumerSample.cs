using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class ProdConsumerSample
    {
        public static void ProducerConsumerSample()
        {
            BlockingCollection<int> blockingCollection = new BlockingCollection<int>(boundedCapacity: 10);
            HashSet<int> uniqueData = new HashSet<int>();  // 중복 체크를 위한 HashSet
            object lockObj = new object();  // HashSet 접근 시 스레드 안전성을 보장하기 위한 락

            // Producer 생성 및 실행
            Producer producer = new Producer(blockingCollection);
            Task producerTask = Task.Run(() => producer.Produce());

            // Consumer 생성 및 실행
            Consumer consumer = new Consumer(blockingCollection, uniqueData, lockObj);
            Task consumerTask = Task.Run(() => consumer.Consume());

            // Producer 및 Consumer가 완료될 때까지 대기
            Task.WaitAll(producerTask, consumerTask);

            Console.WriteLine("모든 작업이 완료되었습니다.");
        }
    }
}
