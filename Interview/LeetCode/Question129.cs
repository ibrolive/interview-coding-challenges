using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question129
    {
        public int SumNumbers(TreeNode root)
        {
            if (root == null)
                return 0;

            Stack<TreeNode> visitedNodes = new Stack<TreeNode>();
            Stack<int> values = new Stack<int>();
            TreeNode currentNode = null;
            int sum = 0,
                currentValue = 0;

            visitedNodes.Push(root);
            values.Push(root.val);

            while (visitedNodes.Count != 0)
            {
                currentNode = visitedNodes.Pop();
                currentValue = currentNode.val;

                if (currentNode.left == null && currentNode.right == null)
                    sum += currentValue;
                else
                {
                    if (currentNode.left != null)
                    {
                        visitedNodes.Push(currentNode.left);
                        values.Push(currentValue * 10 + currentNode.left.val);
                    }

                    if (currentNode.right != null)
                    {
                        visitedNodes.Push(currentNode.right);
                        values.Push(currentValue * 10 + currentNode.right.val);
                    }
                }
            }

            return sum;
        }
    }
}
