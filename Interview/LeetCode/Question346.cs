using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question346
    {

    }

    class MovingAverage
    {
        private int windowSize = 0;
        private Queue<int> queue = new Queue<int>();

        public MovingAverage(int size)
        {
            this.windowSize = size;
        }

        public double Next(int val)
        {
            int actualWindowSize = 0,
                currentVal = 0,
                temp = 0,
                counter = 0; ;

            queue.Enqueue(val);

            if (queue.Count < this.windowSize)
                actualWindowSize = queue.Count;
            else
            {
                actualWindowSize = this.windowSize;

                if (queue.Count > this.windowSize)
                    queue.Dequeue();
            }

            counter = actualWindowSize;

            while (counter > 0)
            {
                currentVal = queue.Dequeue();
                temp += currentVal;

                queue.Enqueue(currentVal);

                counter--;
            }

            return (double)(temp) / (double)(actualWindowSize);
        }
    }
}
