using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question536
    {
        public static void EntryPoint()
        {
            (new Question536()).Str2tree("-1");
        }

        public TreeNode Str2tree(string s)
        {
            if (s == string.Empty)
                return null;

            return Helper(s, 0, s.Length - 1);
        }

        private TreeNode Helper(string s, int start, int end)
        {
            int sign = 1,
                rootVal = 0,
                index,
                lCount = 0,
                rCount = 0;

            if (s[start] == '-')
            {
                sign = -1;
                start++;
            }

            while (start <= end && s[start] >= '0' && s[start] <= '9')
                rootVal = rootVal * 10 + (s[start++] - '0');

            rootVal = rootVal * sign;

            TreeNode root = new TreeNode(rootVal);

            index = start;

            while (index <= end)
            {
                if (s[index] == '(')
                    lCount++;
                else if (s[index] == ')')
                    rCount++;

                if (lCount == rCount && lCount != 0)
                {
                    if (root.left == null)
                    {
                        root.left = Helper(s, start + 1, index - 1);
                        start = index + 1;
                        lCount = rCount = 0;
                    }
                    else
                        root.right = Helper(s, start + 1, index - 1);
                }

                index++;
            }

            return root;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
