using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question110
    {
        public bool IsBalanced(BinaryTree.Node root)
        {
            if (root == null)
                return true;
            else if (Math.Abs(GetDepth(root.LeftNode) - GetDepth(root.RightNode)) <= 1 && IsBalanced(root.LeftNode) && IsBalanced(root.RightNode))
                return true;
            else
                return false;
        }

        public int GetDepth(BinaryTree.Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetDepth(node.LeftNode) + 1, GetDepth(node.RightNode) + 1);
        }
    }
}