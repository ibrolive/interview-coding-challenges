using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1026
    {
        // https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/discuss/274610/JavaC++Python-Top-Down
        public int MaxAncestorDiff(TreeNode root)
        {
            return DFS(root, root.val, root.val);
        }

        public int DFS(TreeNode root, int mn, int mx)
        {
            if (root == null)
                return mx - mn;

            mx = Math.Max(mx, root.val);
            mn = Math.Min(mn, root.val);

            return Math.Max(DFS(root.left, mn, mx), DFS(root.right, mn, mx));
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
