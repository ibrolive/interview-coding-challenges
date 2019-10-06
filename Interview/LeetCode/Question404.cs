using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question404
    {
        public int SumOfLeftLeaves(BinaryTree.Node root)
        {
            if (root == null || (root.LeftNode == null && root.RightNode == null))
                return 0;

            int result = 0;
            Queue<BinaryTree.Node> level = new Queue<BinaryTree.Node>();
            BinaryTree.Node currentNode = null;

            level.Enqueue(root);

            while (level.Count != 0)
            {
                currentNode = level.Dequeue();

                if (currentNode.LeftNode != null && currentNode.LeftNode.LeftNode == null && currentNode.LeftNode.RightNode == null)
                    result += currentNode.LeftNode.Value;
                if (currentNode.LeftNode != null)
                    level.Enqueue(currentNode.LeftNode);
                if (currentNode.RightNode != null)
                    level.Enqueue(currentNode.RightNode);
            }

            return result;
        }
    }
}