using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview
{
    class Question94
    {
        public static void EntryPoint()
        {
            BinaryTree.Node node1 = new BinaryTree.Node(1);
            BinaryTree.Node node2 = new BinaryTree.Node(2);
            BinaryTree.Node node3 = new BinaryTree.Node(3);
            BinaryTree.Node node4 = new BinaryTree.Node(4);
            BinaryTree.Node node5 = new BinaryTree.Node(5);
            BinaryTree.Node node6 = new BinaryTree.Node(6);
            BinaryTree.Node node7 = new BinaryTree.Node(7);

            node1.LeftNode = node2;
            node1.RightNode = node3;
            node2.LeftNode = node4;
            node2.RightNode = node5;
            node3.LeftNode = node6;
            node3.RightNode = node7;

            (new Question94()).InorderTraversal(node1);
        }

        public IList<int> InorderTraversal(BinaryTree.Node root)
        {
            List<int> result = new List<int>();
            Stack<BinaryTree.Node> stack = new Stack<BinaryTree.Node>();
            BinaryTree.Node currentNode = root;

            while (currentNode != null || stack.Count != 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftNode;
                }

                if (stack.Count != 0)
                {
                    currentNode = stack.Pop();
                    result.Add(currentNode.Value);
                    currentNode = currentNode.RightNode;
                }
            }

            return result;
        }
    }
}