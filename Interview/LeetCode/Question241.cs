using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question241
    {
        public static void EntryPoint()
        {
            (new Question241()).DiffWaysToCompute("2*3-4*5");
        }

        // https://leetcode.com/problems/different-ways-to-add-parentheses/discuss/66342/Share-a-clean-and-short-JAVA-solution
        public IList<int> DiffWaysToCompute(string input)
        {
            IList<int> list = new List<int>(),
                       tempA = null,
                       tempB = null;

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' ||
                    input[i] == '-' ||
                    input[i] == '*')
                {
                    tempA = DiffWaysToCompute(input.Substring(0, i - 0));
                    tempB = DiffWaysToCompute(input.Substring(i + 1, input.Length - i - 1));

                    foreach (var itemA in tempA)
                        foreach (var itemB in tempB)
                        {
                            if (input[i] == '+')
                                list.Add(itemA + itemB);
                            else if (input[i] == '-')
                                list.Add(itemA - itemB);
                            else if (input[i] == '*')
                                list.Add(itemA * itemB);
                        }
                }
            }

            if (list.Count == 0)
                list.Add(Convert.ToInt32(input));

            return list;
        }
    }
}
