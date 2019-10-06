using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question482
    {
        public string LicenseKeyFormatting(string S, int K)
        {
            int count = 0;
            Stack<char> reformatedKey = new Stack<char>();
            List<char> result = new List<char>();

            for (int i = S.Length - 1; i >= 0; i--)
            {
                if (S[i] != '-')
                {
                    reformatedKey.Push(S[i]);
                    count++;
                }

                if (count == K)
                {
                    reformatedKey.Push('-');
                    count = 0;
                }
            }

            while (reformatedKey.Count != 0 && reformatedKey.Peek() == '-')
                reformatedKey.Pop();

            while (reformatedKey.Count != 0)
                result.Add(reformatedKey.Pop());

            if (result.Count != 0)
                return new string(result.ToArray()).ToUpper();
            else
                return string.Empty;
        }
    }
}
