using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question102
    {
        public static void EntryPoint()
        {
            BinaryTree.Node Node1 = new BinaryTree.Node(3);
            BinaryTree.Node Node2 = new BinaryTree.Node(9);
            BinaryTree.Node Node3 = new BinaryTree.Node(20);
            Node1.LeftNode = Node2;
            Node1.RightNode = Node3;
            BinaryTree.Node Node4 = new BinaryTree.Node(15);
            BinaryTree.Node Node5 = new BinaryTree.Node(7);
            Node2.LeftNode = Node4;
            Node2.RightNode = Node5;
            (new Question102()).LevelOrder(Node1);
        }

        public IList<IList<int>> LevelOrder(BinaryTree.Node root)
        {
            if (root == null)
                return new List<IList<int>>();

            int sizeInLevel = 0;
            IList<IList<int>> results = new List<IList<int>>();
            IList<int> resultInLevel = null;
            Queue<BinaryTree.Node> level = new Queue<BinaryTree.Node>();
            BinaryTree.Node currentNode = null;

            level.Enqueue(root);

            while (level.Count != 0)
            {
                sizeInLevel = level.Count;
                resultInLevel = new List<int>();

                while (sizeInLevel != 0)
                {
                    currentNode = level.Dequeue();

                    if (currentNode.LeftNode != null)
                        level.Enqueue(currentNode.LeftNode);
                    if (currentNode.RightNode != null)
                        level.Enqueue(currentNode.RightNode);

                    resultInLevel.Add(currentNode.Value);
                    sizeInLevel--;
                }

                results.Add(resultInLevel);
            }

            return results;
        }
    }
}