using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question863
    {
        public static void EntryPoint()
        {
            TreeNode node0 = new TreeNode(0);
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(8);

            node3.left = node5;
            node3.right = node1;
            node5.left = node6;
            node5.right = node2;
            node2.left = node7;
            node2.right = node4;
            node1.left = node0;
            node1.right = node8;

            (new Question863()).DistanceK(node3, node5, 2);
        }

        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            IList<int> result = new List<int>();
            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<int> queue2 = new Queue<int>();
            int count = 0,
                temp = 0,
                distance = 0;
            TreeNode tempNode = null;
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
            HashSet<int> visited = new HashSet<int>();

            queue1.Enqueue(root);

            while (queue1.Count > 0)
            {
                count = queue1.Count;

                while (count-- > 0)
                {
                    tempNode = queue1.Dequeue();

                    if (!dictionary.Keys.Contains(tempNode.val))
                        dictionary[tempNode.val] = new List<int>();

                    if (tempNode.left != null)
                    {
                        if (!dictionary.Keys.Contains(tempNode.left.val))
                            dictionary[tempNode.left.val] = new List<int>();

                        dictionary[tempNode.val].Add(tempNode.left.val);
                        dictionary[tempNode.left.val].Add(tempNode.val);
                        queue1.Enqueue(tempNode.left);
                    }

                    if (tempNode.right != null)
                    {
                        if (!dictionary.Keys.Contains(tempNode.right.val))
                            dictionary[tempNode.right.val] = new List<int>();

                        dictionary[tempNode.val].Add(tempNode.right.val);
                        dictionary[tempNode.right.val].Add(tempNode.val);
                        queue1.Enqueue(tempNode.right);
                    }
                }
            }

            queue2.Enqueue(target.val);
            visited.Add(target.val);

            while (queue2.Count > 0)
            {
                if (distance == K)
                {
                    while (queue2.Count > 0)
                        result.Add(queue2.Dequeue());

                    break;
                }
                else
                {
                    count = queue2.Count;

                    while (count-- > 0)
                    {
                        temp = queue2.Dequeue();

                        foreach (var item in dictionary[temp])
                            if (!visited.Contains(item))
                            {
                                queue2.Enqueue(item);
                                visited.Add(item);
                            }
                    }

                    distance++;
                }
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
