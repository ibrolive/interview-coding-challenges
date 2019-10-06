using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question298
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

            (new Question298()).LongestConsecutive(node1);
        }

        private int _length = 0;

        public int LongestConsecutive(TreeNode root)
        {
            Helper(root);

            return _length;
        }

        private int Helper(TreeNode node)
        {
            if (node == null)
                return 0;

            int l = Helper(node.left),
                r = Helper(node.right),
                cur = 1;

            if ((node.left != null && node.left.val - 1 == node.val) || node.left == null)
                cur = l + 1;

            if ((node.right != null && node.right.val - 1 == node.val) || node.right == null)
                cur = Math.Max(cur, r + 1);

            _length = Math.Max(_length, cur);

            return cur;
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
