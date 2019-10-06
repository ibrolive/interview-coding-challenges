using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question124
    {
        int Max = Int32.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            Helper(root);
            return Max;
        }

        private int Helper(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftMax = Helper(root.left),
                rightMax = Helper(root.right),
                currentMax = 0;

            currentMax = Math.Max(currentMax, Math.Max(leftMax + root.val, rightMax + root.val));
            Max = Math.Max(Max, leftMax + root.val + rightMax);

            return currentMax;
        }
    }
}
