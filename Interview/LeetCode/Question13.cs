using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question13
    {
        public int RomanToInt(string s)
        {
            int result = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == 'V' && i - 1 >= 0 && s[i - 1] == 'I')
                {
                    result += 4;
                    i--;
                }
                else if (s[i] == 'X' && i - 1 >= 0 && s[i - 1] == 'I')
                {
                    result += 9;
                    i--;
                }
                else if (s[i] == 'L' && i - 1 >= 0 && s[i - 1] == 'X')
                {
                    result += 40;
                    i--;
                }
                else if (s[i] == 'C' && i - 1 >= 0 && s[i - 1] == 'X')
                {
                    result += 90;
                    i--;
                }
                else if (s[i] == 'D' && i - 1 >= 0 && s[i - 1] == 'C')
                {
                    result += 400;
                    i--;
                }
                else if (s[i] == 'M' && i - 1 >= 0 && s[i - 1] == 'C')
                {
                    result += 900;
                    i--;
                }
                else if (s[i] == 'I')
                    result += 1;
                else if (s[i] == 'V')
                    result += 5;
                else if (s[i] == 'X')
                    result += 10;
                else if (s[i] == 'L')
                    result += 50;
                else if (s[i] == 'C')
                    result += 100;
                else if (s[i] == 'D')
                    result += 500;
                else if (s[i] == 'M')
                    result += 1000;
            }

            return result;
        }
    }
}
