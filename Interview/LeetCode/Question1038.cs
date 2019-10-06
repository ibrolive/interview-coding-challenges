using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1038
    {
        private int _max = 0;

        public TreeNode BstToGst(TreeNode root)
        {
            return Helper(root);
        }

        private TreeNode Helper(TreeNode node)
        {
            if (node == null)
                return null;

            TreeNode rNode = Helper(node.right),
                     gstNode = new TreeNode(node.val + _max);

            if (gstNode.val > _max)
                _max = gstNode.val;

            TreeNode lNode = Helper(node.left);

            gstNode.left = lNode;
            gstNode.right = rNode;

            return gstNode;
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
