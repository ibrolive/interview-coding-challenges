using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question476
    {
        public static void EntryPoint()
        {
            (new Question476()).FindComplement(5);
        }

        public int FindComplement(int num)
        {
            int result = 0;
            bool nonZero = false;

            for (int i = 30; i >= 0; i--)
                if (!nonZero)
                {
                    if (((num >> i) & 1) == 1)
                    {
                        nonZero = true;
                        i++;
                    }
                }
                else
                    result += (~((num >> i) & 1) & 1) << i;

            return result;
        }
    }
}