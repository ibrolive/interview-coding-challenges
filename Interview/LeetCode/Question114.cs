using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question114
    {
        public void Flatten(BinaryTree.Node root)
        {
            if (root == null)
                return;

            BinaryTree.Node tempNode = null,
                            lastNode = null;

            Flatten(root.LeftNode);
            Flatten(root.RightNode);

            if (root.LeftNode != null)
            {
                tempNode = root.RightNode;
                root.RightNode = root.LeftNode;
                root.LeftNode = null;
                lastNode = root.RightNode;

                while (lastNode.RightNode != null)
                    lastNode = lastNode.RightNode;

                lastNode.RightNode = tempNode;
            }
        }
    }
}