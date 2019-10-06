using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question235
    {
        public BinaryTree.Node LowestCommonAncestor(BinaryTree.Node root, BinaryTree.Node p, BinaryTree.Node q)
        {
            if (p.Value < root.Value && q.Value < root.Value)
                return LowestCommonAncestor(root.LeftNode, p, q);
            else if (p.Value > root.Value && q.Value > root.Value)
                return LowestCommonAncestor(root.RightNode, p, q);
            else
                return root;
        }
    }
}