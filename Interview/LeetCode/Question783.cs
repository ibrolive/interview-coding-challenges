using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interview.LeetCode
{
    class Question783
    {
        private int _min = Int32.MaxValue;

        public int MinDiffInBST(TreeNode root)
        {
            Helper(root);

            return _min;
        }

        private int[] Helper(TreeNode node)
        {
            if (node.left == null && node.right == null)
                return new int[] { node.val, node.val };

            int[] left,
                  right,
                  return_package = new int[2];

            if (node.left != null)
            {
                left = Helper(node.left);
                _min = Math.Abs(node.val - left[1]) > _min ? _min : Math.Abs(node.val - left[1]);
                return_package[0] = left[0];
            }
            else
                return_package[0] = node.val;

            if (node.right != null)
            {
                right = Helper(node.right);
                _min = Math.Abs(node.val - right[0]) > _min ? _min : Math.Abs(node.val - right[0]);
                return_package[1] = right[1];
            }
            else
                return_package[1] = node.val;

            return return_package;
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
