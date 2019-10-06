using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question362
    {
    }

    public class HitCounter
    {
        Queue<int> queue = null;

        public HitCounter()
        {
            queue = new Queue<int>();
        }

        public void Hit(int timestamp)
        {

            queue.Enqueue(timestamp);
        }

        public int GetHits(int timestamp)
        {
            while (queue.Count > 0 && timestamp - queue.Peek() >= 300)
                queue.Dequeue();

            return queue.Count();
        }
    }
}
