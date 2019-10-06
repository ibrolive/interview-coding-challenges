using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question270
    {
        public static void EntryPoint()
        {
            //TreeNode node1 = new TreeNode(4);
            //TreeNode node2 = new TreeNode(2);
            //TreeNode node3 = new TreeNode(5);
            //TreeNode node4 = new TreeNode(1);
            //TreeNode node5 = new TreeNode(3);

            //node1.left = node2;
            //node1.right = node3;
            //node2.left = node4;
            //node2.right = node5;

            //TreeNode node1 = new TreeNode(1);
            //TreeNode node2 = new TreeNode(2);

            TreeNode node1 = new TreeNode(1500000000);
            TreeNode node2 = new TreeNode(1400000000);

            node1.left = node2;

            (new Question270()).ClosestValue(node1, -1500000000.0);
        }

        private int closestVal = 0;
        private double gap = double.MaxValue;

        public int ClosestValue(TreeNode root, double target)
        {
            helper(root, target);

            return closestVal;
        }

        private void helper(TreeNode root, double target)
        {
            if (root != null)
            {
                if (gap > Math.Abs(root.val - target))
                {
                    gap = Math.Abs(root.val - target);
                    closestVal = root.val;
                }

                if (root.val == target)
                    return;
                else if (root.val < target)
                    helper(root.right, target);
                else
                    helper(root.left, target);
            }
        }
    }
}
