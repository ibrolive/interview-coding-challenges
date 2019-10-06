using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question103
    {
        public IList<IList<int>> ZigzagLevelOrder(BinaryTree.Node root)
        {
            if (root == null)
                return new List<IList<int>>();

            IList<IList<int>> results = new List<IList<int>>();
            IList<int> resultInLevel = new List<int>();
            Stack<BinaryTree.Node> oddLevel = new Stack<BinaryTree.Node>();
            Stack<BinaryTree.Node> evenLevel = new Stack<BinaryTree.Node>();
            int level = 1;
            BinaryTree.Node currentNode = null;

            oddLevel.Push(root);

            while (oddLevel.Count != 0 || evenLevel.Count != 0)
            {
                resultInLevel = new List<int>();

                if (level % 2 != 0)
                {
                    while (oddLevel.Count() != 0)
                    {
                        currentNode = oddLevel.Pop();

                        if (currentNode.LeftNode != null)
                            evenLevel.Push(currentNode.LeftNode);
                        if (currentNode.RightNode != null)
                            evenLevel.Push(currentNode.RightNode);

                        resultInLevel.Add(currentNode.Value);
                    }
                }
                else
                {
                    while (evenLevel.Count() != 0)
                    {
                        currentNode = evenLevel.Pop();

                        if (currentNode.RightNode != null)
                            oddLevel.Push(currentNode.RightNode);
                        if (currentNode.LeftNode != null)
                            oddLevel.Push(currentNode.LeftNode);

                        resultInLevel.Add(currentNode.Value);
                    }
                }

                results.Add(resultInLevel);
                level++;
            }

            return results;
        }
    }
}