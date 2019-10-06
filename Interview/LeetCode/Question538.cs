using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question538
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(5);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(13);

            node2.left = node1;
            node2.right = node3;

            (new Question538()).ConvertBST(node2);
        }

        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
                return root;

            int temp = 0;
            TreeNode node = null;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            DFS(root, stack);

            node = stack.Pop();
            temp = node.val;

            while (stack.Count != 0)
            {
                node = stack.Pop();
                node.val += temp;

                temp = node.val;
            }

            return root;
        }

        public void DFS(TreeNode node, Stack<TreeNode> stack)
        {
            if (node != null)
            {
                DFS(node.left, stack);
                stack.Push(node);
                DFS(node.right, stack);
            }
        }
    }
}
