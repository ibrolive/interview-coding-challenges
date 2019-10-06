using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question100
    {
        public bool IsSameTree(BinaryTree.Node p, BinaryTree.Node q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.Value == q.Value)
                return IsSameTree(p.LeftNode, q.LeftNode) && IsSameTree(p.RightNode, q.RightNode);
            return false;
        }
    }
}