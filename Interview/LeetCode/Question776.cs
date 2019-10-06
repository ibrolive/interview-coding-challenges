using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question776
    {
        // https://leetcode.com/problems/split-bst/solution/
        public TreeNode[] SplitBST(TreeNode root, int V)
        {
            if (root == null)
                return new TreeNode[] { null, null };
            else if (root.val <= V)
            {
                TreeNode[] bns = SplitBST(root.right, V);

                root.right = bns[0];
                bns[0] = root;

                return bns;
            }
            else
            {
                TreeNode[] bns = SplitBST(root.left, V);

                root.left = bns[1];
                bns[1] = root;

                return bns;
            }
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
