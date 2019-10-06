using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question166
    {
        public static void EntryPoint()
        {
            (new Question166()).FractionToDecimal(-4, 333);
        }

        public string FractionToDecimal(int numerator, int denominator)
        {
            if (denominator == 0)
                return string.Empty;
            else if (numerator == 0)
                return "0";

            StringBuilder result = new StringBuilder();
            Hashtable hash = new Hashtable();
            long temp = 0;
            long longNumerator = Math.Abs((long)numerator);
            long longDenominator = Math.Abs((long)denominator);

            if (numerator < 0 ^ denominator < 0)
                result.Append("-");

            result.Append(longNumerator / longDenominator);

            temp = longNumerator % longDenominator;

            if (temp != 0)
            {
                result.Append(".");

                while (temp != 0)
                {
                    if (hash.ContainsKey(temp))
                    {
                        result.Insert((int)hash[temp], "(");
                        result.Append(")");

                        break;
                    }
                    else
                    {
                        hash.Add(temp, result.Length);
                        result.Append(temp * 10 / longDenominator);
                        temp = temp * 10 % longDenominator;
                    }
                }
            }

            return result.ToString();
        }
    }
}
