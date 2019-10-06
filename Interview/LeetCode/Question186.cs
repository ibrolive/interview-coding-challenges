using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question186
    {
        public void ReverseWords(char[] s)
        {
            if (s == null || s.Length == 0 || s.Length == 1)
                return;

            int start = 0,
                end = 0;

            ReverseBlock(s, 0, s.Length - 1);

            for (int k = 0; k <= s.Length - 1; k++)
            {
                if (s[k] == ' ' || k == s.Length - 1)
                {
                    if (s[k] == ' ')
                        end = k - 1;
                    else
                        end = k;

                    ReverseBlock(s, start, end);
                    start = k + 1;
                }
            }
        }

        private void ReverseBlock(char[] array, int start, int end)
        {
            while (start < end)
            {
                array[start] = (char)((int)array[start] + (int)array[end]);
                array[end] = (char)((int)array[start] - (int)array[end]);
                array[start] = (char)((int)array[start] - (int)array[end]);

                start++;
                end--;
            }
        }
    }
}