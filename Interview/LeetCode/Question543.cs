using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question543
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;

            (new Question543()).DiameterOfBinaryTree(node1);
        }

        int maxLength = 0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root != null)
                Helper(root);

            return maxLength;
        }

        private int Helper(TreeNode node)
        {
            int left = node.left == null ? 0 : Helper(node.left),
                right = node.right == null ? 0 : Helper(node.right);

            maxLength = left + right > maxLength ? left + right : maxLength;

            return left >= right ? ++left : ++right;
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
