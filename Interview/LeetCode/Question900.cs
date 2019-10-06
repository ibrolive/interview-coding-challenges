using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question900
    {

    }

    public class RLEIterator
    {
        private int[] array = null;
        private int indexLocation = 0,
                    remain = 0;

        public RLEIterator(int[] A)
        {
            this.array = A;
            this.remain = this.array[0];
        }

        public int Next(int n)
        {
            int result = 0;

            if (indexLocation >= array.Length)
                return -1;

            while (n > remain)
            {
                n -= remain;

                indexLocation += 2;

                if (indexLocation < array.Length)
                    remain = this.array[indexLocation];
                else
                    return -1;
            }

            remain -= n;
            result = this.array[indexLocation + 1];

            if (remain == 0)
            {
                indexLocation += 2;

                if (indexLocation < array.Length)
                    remain = array[indexLocation];
            }

            return result;
        }
    }
}
