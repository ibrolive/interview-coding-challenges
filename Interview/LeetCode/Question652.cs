using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question652
    {
        IList<TreeNode> result = new List<TreeNode>();
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            if (root != null)
                Helper(root);

            return result;
        }

        private string Helper(TreeNode node)
        {
            if (node == null)
                return "#";

            string serialized = node.val.ToString() + Helper(node.left) + Helper(node.right);

            if (!dictionary.Keys.Contains(serialized))
                dictionary.Add(serialized, 1);
            else
                dictionary[serialized] = dictionary[serialized] + 1;

            if (dictionary[serialized] == 2)
                result.Add(node);

            return serialized;
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
