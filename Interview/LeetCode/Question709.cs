using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question709
    {
        public static void EntryPoint()
        {
            (new Question709()).ToLowerCase("Hello");
        }

        public string ToLowerCase(string str)
        {
            StringBuilder builder = new StringBuilder();

            if (str != null && str.Length > 0)
                foreach (var item in str)
                    if (item >= 'A' && item <= 'Z')
                        builder.Append((char)(item + 32));
                    else
                        builder.Append(item);

            return builder.ToString();
        }
    }
}
