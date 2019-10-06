using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question173
    {
        public class BSTIterator
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            public BSTIterator(TreeNode root)
            {
                if (root == null)
                    return;

                TreeNode temp = root;

                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.left;
                }
            }

            public bool HasNext()
            {
                return stack.Count != 0;
            }

            public int Next()
            {
                TreeNode currentNode = stack.Pop(),
                         temp = currentNode.right;

                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.left;
                }

                return currentNode.val;
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
