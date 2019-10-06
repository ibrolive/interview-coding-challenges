using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question507
    {
        public static void EntryPoint()
        {
            (new Question507()).CheckPerfectNumber(28);
        }

        public bool CheckPerfectNumber(int num)
        {
            if (num == 1)
                return false;

            int sum = 1;

            for (int i = 2; i * i < num; i++)
                if (num % i == 0)
                {
                    sum += i;
                    sum += num / i;
                }

            return num == sum;
        }
    }
}
