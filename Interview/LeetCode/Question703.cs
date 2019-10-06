using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question703
    {
        public static void EntryPoint()
        {
            //KthLargest obj = new KthLargest(3, new int[] { 4, 5, 8, 2 });

            //obj.Add(3);
            //obj.Add(5);

            KthLargest obj = new KthLargest(2, new int[] { 0 });

            obj.Add(-1);
            obj.Add(1);
            obj.Add(-2);
        }

        public class KthLargest
        {
            int k = 0,
                actualSize = 0;

            SortedDictionary<int, int> priorityQueue = new SortedDictionary<int, int>();

            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                this.actualSize = nums.Length;

                if (nums.Length != 0)
                    foreach (var item in nums)
                        if (priorityQueue.Keys.Contains(item))
                            priorityQueue[item] = priorityQueue[item] + 1;
                        else
                            priorityQueue.Add(item, 1);
            }

            public int Add(int val)
            {
                this.actualSize++;

                if (priorityQueue.Keys.Contains(val))
                    priorityQueue[val] = priorityQueue[val] + 1;
                else
                    priorityQueue.Add(val, 1);

                while (this.actualSize > this.k)
                {
                    if (priorityQueue.First().Value == 1)
                        priorityQueue.Remove(priorityQueue.First().Key);
                    else
                        priorityQueue[priorityQueue.First().Key] = priorityQueue.First().Value - 1;

                    this.actualSize--;
                }

                return priorityQueue.First().Key;
            }
        }
    }
}
