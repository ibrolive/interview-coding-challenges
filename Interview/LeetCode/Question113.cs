using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question113
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(5);
            TreeNode node2 = new TreeNode(4);
            TreeNode node3 = new TreeNode(8);
            TreeNode node4 = new TreeNode(11);
            TreeNode node5 = new TreeNode(13);
            TreeNode node6 = new TreeNode(4);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(2);
            TreeNode node9 = new TreeNode(5);
            TreeNode node10 = new TreeNode(1);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node3.left = node5;
            node3.right = node6;
            node4.left = node7;
            node4.right = node8;
            node6.left = node9;
            node6.right = node10;

            (new Question113()).PathSum(node1, 22);
        }

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return new List<IList<int>>();

            IList<IList<int>> result = new List<IList<int>>();

            FindSum(root, sum, result, new List<int>());

            return result;
        }

        private void FindSum(TreeNode root, int sum, IList<IList<int>> result, List<int> currentPath)
        {
            List<int> temp = null;

            currentPath.Add(root.val);

            if (root.left == null && root.right == null && sum == root.val)
                result.Add(currentPath);
            else
            {
                if (root.left != null)
                {
                    temp = new List<int>();
                    foreach (var item in currentPath)
                        temp.Add(item);

                    FindSum(root.left, sum - root.val, result, temp);
                }

                if (root.right != null)
                {
                    temp = new List<int>();
                    foreach (var item in currentPath)
                        temp.Add(item);

                    FindSum(root.right, sum - root.val, result, temp);
                }
            }
        }
    }
}
