using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question112
    {
        public bool HasPathSum(BinaryTree.Node root, int sum)
        {
            if (root == null || (root.RightNode == null && root.LeftNode == null && root.Value != sum))
                return false;
            else if (root.RightNode == null && root.LeftNode == null && root.Value == sum)
                return true;

            return HasPathSum(root.RightNode, sum - root.Value) || HasPathSum(root.LeftNode, sum - root.Value);
        }
    }
}