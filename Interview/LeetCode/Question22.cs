using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question22
    {
        public static void EntryPoint()
        {
            (new Question22()).GenerateParenthesis(3);
        }

        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            StringBuilder currentResult = new StringBuilder();

            currentResult.Append("(");
            ComposeResult(result, currentResult, n - 1, n, 1);

            return result;
        }

        private void ComposeResult(IList<string> result, StringBuilder currentResult, int remainLeft, int remainRight, int usedLeft)
        {
            if (remainLeft == 0 && remainRight == 0)
            {
                result.Add(currentResult.ToString());
                return;
            }

            StringBuilder temp = null;

            if (usedLeft > 0 && remainRight > 0)
            {
                temp = new StringBuilder(currentResult.ToString());
                temp.Append(")");
                ComposeResult(result, temp, remainLeft, remainRight - 1, usedLeft - 1);
            }


            if (remainLeft > 0)
            {
                temp = new StringBuilder(currentResult.ToString());
                temp.Append("(");
                ComposeResult(result, temp, remainLeft - 1, remainRight, usedLeft + 1);
            }
        }
    }
}
