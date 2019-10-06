using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question95
    {
        public static void EntryPoint()
        {
            IList<TreeNode> result = (new Question95()).GenerateTrees(3);
        }

        // https://leetcode.com/problems/unique-binary-search-trees-ii/discuss/179626/Simple-Java-Recursion
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();

            return helper(1, n);
        }

        public List<TreeNode> helper(int start, int end)
        {
            List<TreeNode> result = new List<TreeNode>();

            if (start > end)
            {
                result.Add(null);

                return result;
            }

            for (int val = start; val <= end; val++)
            {
                List<TreeNode> temp1 = helper(start, val - 1);
                List<TreeNode> temp2 = helper(val + 1, end);
                for (int i = 0; i < temp1.Count(); i++)
                {
                    for (int j = 0; j < temp2.Count(); j++)
                    {
                        TreeNode node = new TreeNode(val);
                        node.left = temp1[i];
                        node.right = temp2[j];
                        result.Add(node);
                    }
                }
            }

            return result;
        }
    }
}
