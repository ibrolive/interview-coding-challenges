using Interview.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1120
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(2),
                     node2 = new TreeNode(1);

            node1.right = node2;

            (new Question1120()).MaximumAverageSubtree(node1);
        }

        private double _result = Int32.MinValue;

        public double MaximumAverageSubtree(TreeNode root)
        {
            Helper(root);

            return _result;
        }

        public Tuple<double, double> Helper(TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                _result = Math.Max(node.val, _result);
                return new Tuple<double, double>(node.val, 1);
            }

            Tuple<double, double> left = null,
                                  right = null;

            if (node.left != null)
                left = Helper(node.left);

            if (node.right != null)
                right = Helper(node.right);

            _result = Math.Max(((left == null ? 0 : left.Item1) + (right == null ? 0 : right.Item1) + node.val) / ((left == null ? 0 : left.Item2) + (right == null ? 0 : right.Item2) + 1), _result);

            return new Tuple<double, double>((left == null ? 0 : left.Item1) + (right == null ? 0 : right.Item1) + node.val, (left == null ? 0 : left.Item2) + (right == null ? 0 : right.Item2) + 1);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left = null;
            public TreeNode right = null;
            public TreeNode(int x) { val = x; }
        }
    }
}
