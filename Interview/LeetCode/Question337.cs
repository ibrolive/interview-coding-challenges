using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question337
    {
        public int Rob(TreeNode root)
        {
            if (root == null)
                return 0;

            int[] result = DP(root);

            return Math.Max(result[0], result[1]);
        }

        private int[] DP(TreeNode node)
        {
            if (node == null)
                return new int[2];

            int[] leftNode = DP(node.left),
                  rightNode = DP(node.right),
                  result = new int[2];

            result[0] = Math.Max(leftNode[0], leftNode[1]) +
                        Math.Max(rightNode[0], rightNode[1]);
            result[1] = leftNode[0] + rightNode[0] + node.val;

            return result;
        }
    }
}
