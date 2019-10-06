using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question67
    {
        public static void EntryPoint()
        {
            (new Question67()).AddBinary("11", "1");
        }

        public string AddBinary(string a, string b)
        {
            int aLen = a.Length - 1, bLen = b.Length - 1, carrier = 0;
            string result = string.Empty;

            while (aLen >= 0 && bLen >= 0)
            {
                if (carrier == 0)
                {
                    if (a[aLen] == '1' && b[bLen] == '1')
                    {
                        result = '0' + result;
                        carrier = 1;
                    }
                    else if (a[aLen] == '0' && b[bLen] == '0')
                        result = '0' + result;
                    else
                        result = '1' + result;
                }
                else
                {
                    if (a[aLen] == '1' && b[bLen] == '1')
                    {
                        result = '1' + result;
                        carrier = 1;
                    }
                    else if (a[aLen] == '0' && b[bLen] == '0')
                    {
                        result = '1' + result;
                        carrier = 0;
                    }
                    else
                    {
                        result = '0' + result;
                        carrier = 1;
                    }
                }

                aLen--;
                bLen--;
            }

            if (aLen >= 0)
            {
                if (carrier == 0)
                {
                    while (aLen >= 0)
                    {
                        result = a[aLen] + result;
                        aLen--;
                    }
                }
                else
                {
                    while (aLen >= 0)
                    {
                        if (a[aLen] == '1' && carrier == 1)
                        {
                            result = '0' + result;
                            carrier = 1;
                        }
                        else if (a[aLen] == '0' && carrier == 1)
                        {
                            result = '1' + result;
                            carrier = 0;
                        }
                        else
                            result = a[aLen] + result;

                        aLen--;
                    }
                }
            }

            if (bLen >= 0)
            {
                if (carrier == 0)
                {
                    while (bLen >= 0)
                    {
                        result = b[bLen] + result;
                        bLen--;
                    }
                }
                else
                {
                    while (bLen >= 0)
                    {
                        if (b[bLen] == '1' && carrier == 1)
                        {
                            result = '0' + result;
                            carrier = 1;
                        }
                        else if (b[bLen] == '0' && carrier == 1)
                        {
                            result = '1' + result;
                            carrier = 0;
                        }
                        else
                            result = b[bLen] + result;

                        bLen--;
                    }
                }
            }

            if (carrier == 1)
                result = '1' + result;

            return result;
        }
    }
}