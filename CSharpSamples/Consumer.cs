using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class Consumer
    {
        private BlockingCollection<int> _collection;
        private HashSet<int> _uniqueData;
        private object _lockObj;

        public Consumer(BlockingCollection<int> collection, HashSet<int> uniqueData, object lockObj)
        {
            _collection = collection;
            _uniqueData = uniqueData;
            _lockObj = lockObj;
        }

        public void Consume()
        {
            foreach (var item in _collection.GetConsumingEnumerable())
            {
                // 중복 체크 및 데이터 처리
                lock (_lockObj)
                {
                    if (_uniqueData.Contains(item))
                    {
                        Console.WriteLine($"Consumer: Duplicate item {item} found, skipping.");
                    }
                    else
                    {
                        _uniqueData.Add(item);
                        Console.WriteLine($"Consumer: Processing item {item}.");
                    }
                }

                Thread.Sleep(150);  // 소비 속도 조절
            }
        }
    }
}
