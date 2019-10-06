using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question621
    {
        public static void EntryPoint()
        {
            (new Question621()).LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2);
        }

        public int LeastInterval(char[] tasks, int n)
        {
            Hashtable hashtable = new Hashtable();
            int max = 0,
                maxCount = Int32.MinValue,
                partCount = 0,
                partLength = 0,
                emptySlots = 0,
                availableTasks = 0,
                idles = 0;

            foreach (var item in tasks)
            {
                if (!hashtable.ContainsKey(item))
                    hashtable.Add(item, 1);
                else
                    hashtable[item] = (int)hashtable[item] + 1;

                if ((int)hashtable[item] > max)
                {
                    max = (int)hashtable[item];
                    maxCount = 1;
                }
                else if ((int)hashtable[item] == max)
                    maxCount++;
            }

            partCount = max - 1;
            partLength = n - (maxCount - 1);
            emptySlots = partCount * partLength;
            availableTasks = tasks.Length - max * maxCount;
            idles = Math.Max(0, emptySlots - availableTasks);

            return tasks.Length + idles;
        }
    }
}
