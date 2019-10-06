using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question281
    {
    }

    public class ZigzagIterator
    {
        private Queue<int> _queue = new Queue<int>();

        public ZigzagIterator(IList<int> v1, IList<int> v2)
        {
            int length = v1.Count <= v2.Count ? v1.Count : v2.Count;

            for (int i = 0; i < length; i++)
            {
                if (i < v1.Count)
                    this._queue.Enqueue(v1[i]);

                if (i < v2.Count)
                    this._queue.Enqueue(v2[i]);
            }
        }

        public bool HasNext()
        {
            return this._queue.Count == 0;
        }

        public int Next()
        {
            return this._queue.Dequeue();
        }
    }
}
