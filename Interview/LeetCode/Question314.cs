using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question314
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(3);
            TreeNode node2 = new TreeNode(9);
            TreeNode node3 = new TreeNode(20);
            TreeNode node4 = new TreeNode(15);
            TreeNode node5 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node3.left = node4;
            node3.right = node5;

            (new Question314()).VerticalOrder(node1);
        }

        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            Dictionary<int, List<int>> tempDictionary = new Dictionary<int, List<int>>();
            List<int> tempList = null;
            Tuple<TreeNode, int> tempTuple = null;
            int count = 0,
                leftBoundary = 0,
                rightBoundary = 0;

            if (root != null)
            {
                queue.Enqueue(new Tuple<TreeNode, int>(root, 0));

                while (queue.Count > 0)
                {
                    count = queue.Count;

                    while (count-- > 0)
                    {
                        tempTuple = queue.Dequeue();

                        if (tempDictionary.ContainsKey(tempTuple.Item2))
                            tempDictionary[tempTuple.Item2].Add(tempTuple.Item1.val);
                        else
                        {
                            tempList = new List<int>();
                            tempList.Add(tempTuple.Item1.val);
                            tempDictionary.Add(tempTuple.Item2, tempList);
                        }

                        if (tempTuple.Item1.left != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(tempTuple.Item1.left, tempTuple.Item2 - 1));

                            leftBoundary = tempTuple.Item2 - 1 < leftBoundary ? tempTuple.Item2 - 1 : leftBoundary;
                        }

                        if (tempTuple.Item1.right != null)
                        {
                            queue.Enqueue(new Tuple<TreeNode, int>(tempTuple.Item1.right, tempTuple.Item2 + 1));

                            rightBoundary = tempTuple.Item2 + 1 < rightBoundary ? tempTuple.Item2 + 1 : rightBoundary;
                        }
                    }
                }

                for (int i = leftBoundary; i <= rightBoundary; i++)
                    result.Add(tempDictionary[i]);
            }

            return result;
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
