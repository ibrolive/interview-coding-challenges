using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question513
    {
        public int FindBottomLeftValue(BinaryTree.Node root)
        {
            BinaryTree.Node mostLeftNode = null, currentNode = null;
            Queue<BinaryTree.Node> level = new Queue<BinaryTree.Node>();
            int currentLevelCount = 0;

            level.Enqueue(root);
            
            while(level.Count != 0)
            {
                currentLevelCount = level.Count;
                mostLeftNode = level.Peek();

                do
                {
                    currentNode = level.Dequeue();

                    if (currentNode.LeftNode != null)
                        level.Enqueue(currentNode.LeftNode);
                    if (currentNode.RightNode != null)
                        level.Enqueue(currentNode.RightNode);
                }
                while (--currentLevelCount > 0);
            }

            return mostLeftNode.Value;
        }
    }
}