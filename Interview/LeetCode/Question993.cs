using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question993
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;

            (new Question993()).IsCousins(node1, 4, 3);
        }

        public bool IsCousins(TreeNode root, int x, int y)
        {
            Queue<AnnotationNode> queue = new Queue<AnnotationNode>();
            AnnotationNode tempNode = null;
            TreeNode parentX = null,
                     parentY = null;
            int count = 1;
            bool foundX = false,
                 foundY = false;

            if (root == null)
                return false;

            queue.Enqueue(new AnnotationNode(root, null));

            while (queue.Count > 0)
            {
                count = queue.Count;

                while (count-- > 0)
                {
                    tempNode = queue.Dequeue();

                    if (tempNode.Node.val == x)
                    {
                        parentX = tempNode.ParentNode;
                        foundX = true;
                    }
                    else if (tempNode.Node.val == y)
                    {
                        parentY = tempNode.ParentNode;
                        foundY = true;
                    }

                    if (tempNode.Node.left != null)
                        queue.Enqueue(new AnnotationNode(tempNode.Node.left, tempNode.Node));

                    if (tempNode.Node.right != null)
                        queue.Enqueue(new AnnotationNode(tempNode.Node.right, tempNode.Node));

                    if (parentX != parentY && foundX && foundY)
                        return true;
                }

                parentX = null;
                parentY = null;
                foundX = false;
                foundY = false;
            }

            return false;
        }

        public class AnnotationNode
        {
            public TreeNode Node = null,
                            ParentNode = null;

            public AnnotationNode(TreeNode node, TreeNode parent)
            {
                this.Node = node;
                this.ParentNode = parent;
            }
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
