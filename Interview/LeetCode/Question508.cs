using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question508
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(5);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(-3);

            node1.left = node2;
            node1.right = node3;

            (new Question508()).FindFrequentTreeSum(node1);
        }

        int max = Int32.MinValue;
        Hashtable hash = new Hashtable();
        List<int> result = new List<int>();

        public int[] FindFrequentTreeSum(TreeNode root)
        {
            if (root == null)
                return new int[] { };

            Helper(root);

            foreach (var item in hash.Keys)
            {
                if ((int)hash[item] > max)
                {
                    result.Clear();
                    result.Add((int)item);

                    max = (int)hash[item];
                }
                else if ((int)hash[item] == max)
                    result.Add((int)item);
            }

            return result.ToArray();
        }

        private int Helper(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftSum = Helper(node.left),
                rightSum = Helper(node.right);

            if (!hash.Contains(node.val + leftSum + rightSum))
                hash.Add(node.val + leftSum + rightSum, 1);
            else
                hash[node.val + leftSum + rightSum] = (int)hash[node.val + leftSum + rightSum] + 1;

            return node.val + leftSum + rightSum;
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
