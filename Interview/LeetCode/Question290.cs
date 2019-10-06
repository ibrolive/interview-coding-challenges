using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question290
    {
        public bool WordPattern(string pattern, string str)
        {
            Hashtable hashPattern = new Hashtable(),
                      hashStr = new Hashtable();
            string[] splitedString = str.Split(' ');

            if (pattern.Length != splitedString.Length)
                return false;

            for (int i = 0; i <= pattern.Length - 1; i++)
            {
                if ((hashPattern.Contains(pattern[i]) && (string)hashPattern[pattern[i]] != splitedString[i]) ||
                    (hashStr.Contains(splitedString[i]) && (char)hashStr[splitedString[i]] != pattern[i]))
                    return false;

                if (!hashPattern.Contains(pattern[i]))
                    hashPattern.Add(pattern[i], splitedString[i]);

                if (!hashStr.Contains(splitedString[i]))
                    hashStr.Add(splitedString[i], pattern[i]);
            }

            return true;
        }
    }
}