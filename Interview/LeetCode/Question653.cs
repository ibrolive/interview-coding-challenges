using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question653
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(5);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(6);
            TreeNode node4 = new TreeNode(2);
            TreeNode node5 = new TreeNode(4);
            TreeNode node6 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.right = node6;

            (new Question653()).FindTarget(node1, 10);
        }

        public bool FindTarget(TreeNode root, int k)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            TreeNode currentNode = null;

            nodes.Enqueue(root);

            while (nodes.Count != 0)
            {
                currentNode = nodes.Dequeue();

                if (currentNode.val != k - currentNode.val && findNode(root, k - currentNode.val))
                    return true;

                if (currentNode.left != null)
                    nodes.Enqueue(currentNode.left);

                if (currentNode.right != null)
                    nodes.Enqueue(currentNode.right);
            }

            return false;
        }

        private bool findNode(TreeNode bst, int target)
        {
            if (bst != null && bst.val > target)
                return findNode(bst.left, target);
            else if (bst != null && bst.val < target)
                return findNode(bst.right, target);
            else if (bst != null && bst.val == target)
                return true;

            return false;
        }
    }
}
