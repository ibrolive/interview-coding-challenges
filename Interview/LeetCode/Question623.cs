using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question623
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(4);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(1);

            node1.left = node2;
            node2.left = node3;
            node2.right = node4;
            
            (new Question623()).AddOneRow(node1, 1, 3);
        }

        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (d == 1)
            {
                TreeNode newRoot = new TreeNode(v);
                newRoot.left = root;

                return newRoot;
            }

            TreeNode tempNode = null,
                     tempLeft = null,
                     tempRight = null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int count = 1,
                currentHeight = 1;

            queue.Enqueue(root);

            while (currentHeight++ != d - 1 && queue.Count != 0)
            {
                while (count-- != 0)
                {
                    tempNode = queue.Dequeue();

                    if (tempNode.left != null)
                        queue.Enqueue(tempNode.left);

                    if (tempNode.right != null)
                        queue.Enqueue(tempNode.right);
                }

                count = queue.Count;
            }

            while (queue.Count != 0)
            {
                tempNode = queue.Dequeue();
                tempLeft = tempNode.left;
                tempRight = tempNode.right;

                tempNode.left = new TreeNode(v);
                tempNode.right = new TreeNode(v);

                tempNode.left.left = tempLeft;
                tempNode.right.right = tempRight;
            }

            return root;
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
