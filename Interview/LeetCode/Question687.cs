using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question687
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(4);
            TreeNode node3 = new TreeNode(5);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(4);
            TreeNode node6 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.right = node6;

            (new Question687()).LongestUnivaluePath(node1);
        }

        int currentMaxLength = 0;

        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null)
                return 0;

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            TreeNode currentNode = null;
            int currentLoopMax = 0;

            nodes.Enqueue(root);

            while (nodes.Count != 0)
            {
                currentNode = nodes.Dequeue();

                currentLoopMax = detectLength(currentNode);
                currentMaxLength = Math.Max(currentMaxLength, currentLoopMax);

                if (currentNode.left != null)
                    nodes.Enqueue(currentNode.left);

                if (currentNode.right != null)
                    nodes.Enqueue(currentNode.right);
            }

            return currentMaxLength;
        }

        private int detectLength(TreeNode node)
        {
            int leftLength = 0,
                rightLength = 0;

            if (node.left != null && node.val == node.left.val)
                leftLength = detectLength(node.left) + 1;

            if (node.right != null && node.val == node.right.val)
                rightLength = detectLength(node.right) + 1;

            if (leftLength != 0 && rightLength != 0)
                currentMaxLength = Math.Max(currentMaxLength, leftLength + rightLength);

            if (leftLength == 0 &&
                rightLength == 0)
                return 0;

            return leftLength >= rightLength ? leftLength : rightLength;
        }
    }
}
