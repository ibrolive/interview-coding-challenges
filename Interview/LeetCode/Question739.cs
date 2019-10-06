using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question739
    {
        public int[] DailyTemperatures(int[] T)
        {
            int[] result = new int[T.Length];
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

            for (int i = 0; i < T.Length; i++)
            {
                while (stack.Count > 0 && stack.Peek().Item1 < T[i])
                {
                    result[stack.Peek().Item2] = i - stack.Peek().Item2;
                    stack.Pop();
                }

                stack.Push(new Tuple<int, int>(T[i], i));
            }

            return result;
        }
    }
}
