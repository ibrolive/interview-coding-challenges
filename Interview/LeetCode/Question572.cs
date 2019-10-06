using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question572
    {
        // https://leetcode.com/problems/subtree-of-another-tree/discuss/102724/Java-Solution-tree-traversal
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;

            if (IsSameTree(s, t))
                return true;

            return IsSubtree(s.left, t) || IsSubtree(t.right, t);
        }

        private bool IsSameTree(TreeNode nodeInS, TreeNode nodeInT)
        {
            if (nodeInS == null && nodeInT == null)
                return true;
            else if (nodeInS != null || nodeInT != null)
                return false;
            else if (nodeInS.val != nodeInT.val)
                return false;

            return IsSameTree(nodeInS.left, nodeInT.left) && IsSameTree(nodeInS.right, nodeInT.right);
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
