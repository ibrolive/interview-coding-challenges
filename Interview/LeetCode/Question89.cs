using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question89
    {
        public static void EntryPoint()
        {
            (new Question89()).GrayCode(1);
        }

        // https://leetcode.com/problems/gray-code/discuss/156204/Simple-java-solution-with-comments
        public IList<int> GrayCode(int n)
        {
            IList<int> result = new List<int>();
            int index = 1;

            if (n == 0)
                result.Add(0);
            else
            {
                result.Add(0);
                result.Add(1);                

                while (index < n)
                {
                    for (int i = result.Count() - 1; i >= 0; i--)
                        result.Add((1 << index) + result[i]);

                    index++;
                }
            }

            return result;
        }
    }
}