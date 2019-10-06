using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question669
    {
        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return root;

            if (root.val > R)
                return TrimBST(root.left, L, R);

            if (root.val < L)
                return TrimBST(root.right, L, R);

            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);

            return root;
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
