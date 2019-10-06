using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question929
    {
        public static void EntryPoint()
        {
            (new Question929()).NumUniqueEmails(new string[] { "test.email+alex@leetcode.com",
                                                               "test.e.mail+bob.cathy@leetcode.com",
                                                               "testemail+david@lee.tcode.com" });
        }

        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> set = new HashSet<string>();
            int index = 0;
            bool ignore = false;
            StringBuilder builder = new StringBuilder();

            foreach (var item in emails)
            {
                ignore = false;
                builder.Clear();

                for (index = 0; index < item.Length && item[index] != '@'; index++)
                {
                    if (item[index] == '+')
                    {
                        ignore = true;
                        continue;
                    }
                    else if (ignore)
                        continue;
                    else if (item[index] != '.')
                        builder.Append(item[index]);
                }

                for (; index < item.Length; index++)
                    builder.Append(item[index]);

                if (!set.Contains(builder.ToString()))
                    set.Add(builder.ToString());
            }

            return set.Count;
        }
    }
}
