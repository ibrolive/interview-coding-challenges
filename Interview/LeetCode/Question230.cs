using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question230
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(3);
            TreeNode node2 = new TreeNode(1);
            TreeNode node3 = new TreeNode(4);
            TreeNode node4 = new TreeNode(2);

            node1.left = node2;
            node1.right = node3;
            node2.right = node4;

            (new Question230()).KthSmallest(node1, 1);
        }

        // https://leetcode.com/problems/kth-smallest-element-in-a-bst/discuss/63673/4-Lines-in-C++.
        private int result = 0,
                    position = 0;

        public int KthSmallest(TreeNode root, int k)
        {
            Find(root, k);

            return result;
        }

        private void Find(TreeNode node, int k)
        {
            if (node == null)
                return;

            Find(node.left, k);

            if (++position == k)
                result = node.val;

            Find(node.right, k);
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
