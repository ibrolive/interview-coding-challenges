using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question285
    {
        // https://leetcode.com/problems/inorder-successor-in-bst/discuss/72721/10-(and-4)-lines-O(h)-JavaC++
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            if (p.right != null)
            {
                p = p.right;

                while (p.left != null)
                    p = p.left;

                return p;
            }

            TreeNode candidate = null;

            while (root != p)
                root = (p.val > root.val) ? root.right : (candidate = root).left;

            return candidate;
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
