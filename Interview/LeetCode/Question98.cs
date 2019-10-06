using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question98
    {
        public bool IsValidBST(BinaryTree.Node root)
        {
            return CheckBST(root, long.MinValue, long.MaxValue);
        }

        private bool CheckBST(BinaryTree.Node root, long minValue, long maxValue)
        {
            if (root == null)
                return true;
            else if (root.Value <= minValue || root.Value >= maxValue)
                return false;
            else
                return CheckBST(root.LeftNode, minValue, root.Value) && CheckBST(root.RightNode, root.Value, maxValue);
        }
    }
}