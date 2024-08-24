using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class Producer
    {
        private BlockingCollection<int> _collection;

        public Producer(BlockingCollection<int> collection)
        {
            _collection = collection;
        }

        public void Produce()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Producer: Adding {i} to the collection.");
                _collection.Add(i);  // 데이터 추가
                Thread.Sleep(100);  // 생산 속도 조절
            }

            // 생산 완료 후 CompleteAdding 호출
            _collection.CompleteAdding();
        }
    }
}
