using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question701
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root != null)
                Helper(root, val);

            return root;
        }

        private void Helper(TreeNode node, int val)
        {
            if (node.val > val)
            {
                if (node.left == null)
                    node.left = new TreeNode(val);
                else
                    Helper(node.left, val);
            }
            else
            {
                if (node.right == null)
                    node.right = new TreeNode(val);
                else
                    Helper(node.right, val);
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
