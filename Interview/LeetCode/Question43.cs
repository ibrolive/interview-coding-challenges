using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question43
    {
        public static void EntryPoint()
        {
            (new Question43()).Multiply("2", "3");
        }

        // https://leetcode.com/problems/multiply-strings/discuss/110755/C:-Easy-Solution-with-Explanation-and-Image-Representation-of-the-Solution.(Accepted)
        public string Multiply(string num1, string num2)
        {
            if (num1 == null || num1.Length == 0 || num2 == null || num2.Length == 0)
                return string.Empty;
            else if (num1 == "0" || num2 == "0")
                return "0";

            string[] tempResult = new string[num1.Length + num2.Length];
            StringBuilder result = new StringBuilder();
            int temp = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    temp = (num1[i] - '0') * (num2[j] - '0') + (tempResult[i + j + 1] == string.Empty ? 0 : Convert.ToInt32(tempResult[i + j + 1]));

                    tempResult[i + j + 1] = (temp % 10).ToString();
                    tempResult[i + j] = ((tempResult[i + j] == string.Empty ? 0 : Convert.ToInt32(tempResult[i + j])) + temp / 10).ToString();
                }
            }

            for (int i = 0; i < tempResult.Length; i++)
                if (tempResult[i] != string.Empty)
                    result.Append(tempResult[i]);

            if (result[0] == '0')
                result.Remove(0, 1);

            return result.ToString();
        }
    }
}
