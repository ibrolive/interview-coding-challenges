using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question107
    {
        public IList<IList<int>> LevelOrderBottom(BinaryTree.Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<BinaryTree.Node> queue = new Queue<BinaryTree.Node>();
            Stack<List<int>> stack = new Stack<List<int>>();
            List<int> tempList = null;
            BinaryTree.Node currentNode = null;
            int count = 0;

            if (root != null)
            {
                queue.Enqueue(root);

                while (queue.Count != 0)
                {
                    count = queue.Count;
                    tempList = new List<int>();

                    while (count-- > 0)
                    {
                        currentNode = queue.Dequeue();
                        tempList.Add(currentNode.Value);
                        if (currentNode.LeftNode != null)
                            queue.Enqueue(currentNode.LeftNode);
                        if (currentNode.RightNode != null)
                            queue.Enqueue(currentNode.RightNode);
                    }

                    stack.Push(tempList);
                }

                while (stack.Count != 0)
                    result.Add(stack.Pop());
            }

            return result;
        }
    }
}