using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question222
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + CountNodes(root.left) + CountNodes(root.right);
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
