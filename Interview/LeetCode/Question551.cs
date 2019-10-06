using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question551
    {
        public bool CheckRecord(string s)
        {
            if (s == null || s == string.Empty)
                return false;

            int count = 0, longestCount = 0;
            Hashtable record = new Hashtable();
            char[] temp = s.ToUpper().ToCharArray();

            record.Add('A', 0);

            if (temp[0] == 'A')
                record['A'] = (int)record['A'] + 1;

            for (int i = 1; i <= temp.Length - 1; i++)
            {
                if (temp[i] == 'A')
                    record['A'] = (int)record['A'] + 1;

                if (temp[i] == 'L' && temp[i - 1] == 'L')
                {
                    count++;
                    if (count > longestCount)
                        longestCount = count;
                }
                else
                    count = 0;
            }

            if ((int)record['A'] > 1 || longestCount >= 2)
                return false;

            return true;
        }
    }
}