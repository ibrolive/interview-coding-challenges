using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1022
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(0);
            TreeNode node3 = new TreeNode(1);
            TreeNode node4 = new TreeNode(0);
            TreeNode node5 = new TreeNode(1);
            TreeNode node6 = new TreeNode(0);
            TreeNode node7 = new TreeNode(1);
            TreeNode node8 = new TreeNode(1);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;
            node6.left = node8;

            int result = (new Question1022()).SumRootToLeaf(node1);
        }

        // https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/discuss/270025/JavaC++Python-Recursive-Solution
        public int SumRootToLeaf(TreeNode root)
        {
            return DFS(root, 0);
        }

        public int DFS(TreeNode root, int val)
        {
            if (root == null)
                return 0;

            val = val * 2 + root.val;

            return root.left == root.right ? val : DFS(root.left, val) + DFS(root.right, val);
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
