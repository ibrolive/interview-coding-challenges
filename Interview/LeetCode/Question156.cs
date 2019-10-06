using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question156
    {
        public static void EntryPoint()
        {
            BinaryTree.Node root = new BinaryTree.Node(1);
            BinaryTree.Node node1 = new BinaryTree.Node(2);
            root.LeftNode = node1;

            (new Question156()).UpsideDownBinaryTree(root);
        }

        private BinaryTree.Node emptyPlaceHolder = new BinaryTree.Node(int.MinValue);

        public BinaryTree.Node UpsideDownBinaryTree(BinaryTree.Node root)
        {
            if (root == null)
                return null;

            Queue<BinaryTree.Node> queue = new Queue<BinaryTree.Node>();
            BinaryTree.Node result = null;

            DFS(root, queue);

            result = new BinaryTree.Node(queue.Dequeue().Value);

            RebuildTree(result, queue);

            return result;
        }

        private void DFS(BinaryTree.Node node, Queue<BinaryTree.Node> queue)
        {
            if (node != null)
            {
                DFS(node.LeftNode, queue);
                queue.Enqueue(node);

                if (node.LeftNode != null && node.RightNode == null)
                    queue.Enqueue(new BinaryTree.Node(int.MinValue));
                else
                    DFS(node.RightNode, queue);
            }
        }

        private void RebuildTree(BinaryTree.Node node, Queue<BinaryTree.Node> queue)
        {
            if (queue.Count != 0)
            {
                node.RightNode = new BinaryTree.Node(queue.Dequeue().Value);
                if (queue.Count != 0 && queue.Peek().Value != int.MinValue)
                    node.LeftNode = new BinaryTree.Node(queue.Dequeue().Value);
                else if (queue.Count != 0)
                    queue.Dequeue();

                RebuildTree(node.RightNode, queue);
            }
        }
    }
}