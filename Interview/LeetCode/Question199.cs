using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question199
    {
        public IList<int> RightSideView(BinaryTree.Node root)
        {
            List<int> result = new List<int>();
            Queue<BinaryTree.Node> level = new Queue<BinaryTree.Node>();
            int countInLevel = 0;
            BinaryTree.Node currentNode = null;

            if (root != null)
            {
                level.Enqueue(root);

                while (level.Count != 0)
                {
                    countInLevel = level.Count;

                    while (countInLevel > 0)
                    {
                        currentNode = level.Dequeue();
                        if (currentNode.LeftNode != null)
                            level.Enqueue(currentNode.LeftNode);
                        if (currentNode.RightNode != null)
                            level.Enqueue(currentNode.RightNode);

                        if (countInLevel == 1)
                            result.Add(currentNode.Value);

                        countInLevel--;
                    }
                }
            }

            return result;
        }
    }
}