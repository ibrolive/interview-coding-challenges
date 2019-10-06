using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question541
    {
        public static void EntryPoint()
        {
            (new Question541()).ReverseStr("jlnnxsetgcpsbhsfymrkhfursyissjnsocgdhgfxtxrlvugsaphqzxllwebukgatzfybprfmmfithphckksnvjkcvnsqgsgosfxc", 20);
        }

        public string ReverseStr(string s, int k)
        {
            if (s == null)
                return s;

            char[] tempArray = s.ToCharArray();
            int i, j, border = 1, count = 0;

            for (int n = 0; n < tempArray.Length; n++)
            {
                if (border == 1)
                {
                    i = n;
                    j = (tempArray.Length - count * 2 * k) >= k ? n + k - 1 : tempArray.Length - 1;

                    while (i < j)
                    {
                        tempArray[i] ^= tempArray[j];
                        tempArray[j] ^= tempArray[i];
                        tempArray[i] ^= tempArray[j];

                        i++;
                        j--;
                    }

                    n += k;
                    border += k;
                    count++;
                }

                border = border / 2 == k ? 1 : border + 1;
            }

            return new string(tempArray);
        }
    }
}