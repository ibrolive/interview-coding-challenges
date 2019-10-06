using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question722
    {
        public static void EntryPoint()
        {
            (new Question722()).RemoveComments(new string[]
            {
                "a/*comment",
                "line",
                "more_comment*/b"
            });
        }

        public IList<string> RemoveComments(string[] source)
        {
            StringBuilder builder = new StringBuilder();
            bool isInCommentBlock = false;
            IList<string> result = new List<string>();

            foreach (var item in source)
            {
                for (int i = 0; i < item.Length; i++)
                    if (i + 1 < item.Length)
                    {
                        if (item[i] == '/' && item[i + 1] == '/' && !isInCommentBlock)
                            break;
                        else if (item[i] == '/' && item[i + 1] == '*' && !isInCommentBlock)
                        {
                            isInCommentBlock = true;
                            i++;
                        }
                        else if (item[i] == '*' && item[i + 1] == '/' && isInCommentBlock)
                        {
                            isInCommentBlock = false;
                            i++;
                        }
                        else if (!isInCommentBlock)
                            builder.Append(item[i]);
                    }
                    else if (!isInCommentBlock)
                        builder.Append(item[i]);

                if (builder.Length > 0 && !isInCommentBlock)
                {
                    result.Add(builder.ToString());

                    builder.Clear();
                }
            }

            return result;
        }
    }
}
