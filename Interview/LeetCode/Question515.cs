using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question515
    {
        public static void EntryPoint()
        {
            (new Question515()).LargestValues(null);
        }

        public IList<int> LargestValues(BinaryTree.Node root)
        {
            List<int> result = new List<int>();
            Queue<BinaryTree.Node> queue = new Queue<BinaryTree.Node>();
            int currentMax = int.MinValue, currentLevel = 0;
            BinaryTree.Node currentNode = null;

            if (root != null)
            {
                queue.Enqueue(root);

                while (queue.Count != 0)
                {
                    currentLevel = queue.Count;

                    while (currentLevel != 0)
                    {
                        currentNode = queue.Dequeue();

                        if (currentNode.Value > currentMax)
                            currentMax = currentNode.Value;

                        if (currentNode.LeftNode != null)
                            queue.Enqueue(currentNode.LeftNode);

                        if (currentNode.RightNode != null)
                            queue.Enqueue(currentNode.RightNode);

                        currentLevel--;
                    }

                    result.Add(currentMax);
                    currentMax = int.MinValue;
                }
            }

            return result;
        }
    }
}