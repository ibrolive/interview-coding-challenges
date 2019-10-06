using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question662
    {
        // https://leetcode.com/problems/maximum-width-of-binary-tree/solution/
        public int WidthOfBinaryTree(TreeNode root)
        {
            Queue<AnnotatedNode> queue = new Queue<AnnotatedNode>();
            AnnotatedNode tempNode = null;
            int count = 0,
                left = 0,
                right = 0,
                result = 0;

            queue.Enqueue(new AnnotatedNode(root, 1));

            while (queue.Count != 0)
            {
                count = queue.Count;
                left = queue.Peek().position;

                while (count-- > 0)
                {
                    tempNode = queue.Dequeue();

                    if (tempNode.node.left != null)
                        queue.Enqueue(new AnnotatedNode(tempNode.node.left, tempNode.position * 2));

                    if (tempNode.node.right != null)
                        queue.Enqueue(new AnnotatedNode(tempNode.node.right, tempNode.position * 2 + 1));

                    if (count == 0)
                        right = tempNode.position;
                }

                result = result > right - left + 1 ? result : right - left + 1;
            }

            return result;
        }

        public class AnnotatedNode
        {
            public TreeNode node = null;
            public int position = 0;

            public AnnotatedNode(TreeNode node, int position)
            {
                this.node = node;
                this.position = position;
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
