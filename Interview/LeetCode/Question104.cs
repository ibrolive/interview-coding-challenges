using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question104
    {
        public int MaxDepth(BinaryTree.Node root)
        {
            if (root == null)
                return 0;

            return Math.Max(MaxDepth(root.LeftNode), MaxDepth(root.RightNode)) + 1;
        }
    }
}