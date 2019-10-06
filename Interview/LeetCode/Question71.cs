using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question71
    {
        public static void EntryPoint()
        {
            //(new Question71()).SimplifyPath("/a/./b/../../c/");
            (new Question71()).SimplifyPath("/home/of/foo/../../bar/../../is/./here/.");
            //(new Question71()).SimplifyPath("/home/foo/.ssh/../.ssh2/authorized_keys/");
        }

        public string SimplifyPath(string path)
        {
            StringBuilder result = new StringBuilder();
            Stack<string> stackOfPath = new Stack<string>();
            List<string> output = new List<string>();
            int deleteCount = 0;

            foreach (var item in path.Split('/'))
                if (item == string.Empty || item == ".")
                    continue;
                else
                    stackOfPath.Push(item);

            while (stackOfPath.Count != 0)
            {
                if (stackOfPath.Peek() == "..")
                {
                    stackOfPath.Pop();
                    deleteCount++;

                    continue;
                }

                if (deleteCount > 0)
                {
                    while (deleteCount > 0 && stackOfPath.Count != 0 && stackOfPath.Peek() != "..")
                    {
                        stackOfPath.Pop();
                        deleteCount--;
                    }

                    continue;
                }

                output.Add(stackOfPath.Pop());
                output.Add("/");
            }

            if (output.Count != 0)
            {
                output.Reverse();
                foreach (var item in output)
                    result.Append(item);
            }
            else
                result.Append("/");

            return result.ToString();
        }
    }
}
