using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question250
    {
        // https://leetcode.com/problems/count-univalue-subtrees/discuss/67602/Java-11-lines-added
        // One tree is the subtree of itself (https://leetcode.com/problems/count-univalue-subtrees/discuss/67640/Anyone-know-why-55555null5-is-count-as-6-not-5-and-mistake-in-my-solutions)
        int count = 0;

        public int CountUnivalSubtrees(TreeNode root)
        {
            if (root == null)
                return 0;

            if (Helper(root))
                count++;

            CountUnivalSubtrees(root.left);
            CountUnivalSubtrees(root.right);

            return count;
        }

        private bool Helper(TreeNode root)
        {
            if (root == null)
                return true;

            if (root.left != null && root.left.val != root.val)
                return false;

            if (root.right != null && root.right.val != root.val)
                return false;

            return Helper(root.left) && Helper(root.right);
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
