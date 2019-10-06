using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question313
    {
        public static void EntryPoint()
        {
            (new Question313()).NthSuperUglyNumber(12, new int[] { 2, 7, 13, 19 });
        }

        public int NthSuperUglyNumber(int n, int[] primes)
        {
            SortedSet<int> set = new SortedSet<int>();

            set.Add(1);

            while (n > 1 && set.Count > 0)
            {
                int current = set.Min();

                foreach (var item in primes)
                    if (!set.Contains(current * item) && (long)current * (long)item < Int32.MaxValue)
                        set.Add(current * item);

                set.Remove(current);

                n--;
            }

            return set.Min();
        }
    }
}
