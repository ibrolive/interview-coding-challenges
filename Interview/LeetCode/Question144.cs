using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            IList<int> result = new List<int>();
            TreeNode currentNode = null;

            stack.Push(root);

            while (stack.Count != 0)
            {
                currentNode = stack.Pop();

                result.Add(currentNode.val);

                if (currentNode.left != null)
                    stack.Push(currentNode.left);

                if (currentNode.right != null)
                    stack.Push(currentNode.right);
            }

            return result;
        }
    }
}
