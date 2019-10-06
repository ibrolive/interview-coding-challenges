using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question1167
    {
        public int ConnectSticks(int[] sticks)
        {
            int result = 0;
            MinHeap<int> heap = new MinHeap<int>();

            foreach (var item in sticks)
                heap.Add(item, item);

            while (heap.Count != 1)
            {
                int item1 = heap.ExtractWeight(),
                    item2 = heap.ExtractWeight();

                result += item1 + item2;
                heap.Add(item1 + item2, item1 + item2);
            }

            return result;
        }
    }
}
