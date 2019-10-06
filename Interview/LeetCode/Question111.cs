using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question111
    {
        public int MinDepth(BinaryTree.Node root)
        {
            if (root == null)
                return 0;
            else if (root.LeftNode == null)
                return MinDepth(root.RightNode) + 1;
            else if (root.RightNode == null)
                return MinDepth(root.LeftNode) + 1;
            else
                return Math.Min(MinDepth(root.LeftNode), MinDepth(root.RightNode)) + 1;
        }
    }
}