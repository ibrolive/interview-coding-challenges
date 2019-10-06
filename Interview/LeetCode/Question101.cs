using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question101
    {
        public static void EntryPoint()
        {
            BinaryTree.Node root = new BinaryTree.Node(1);
            BinaryTree.Node node1 = new BinaryTree.Node(2);
            BinaryTree.Node node2 = new BinaryTree.Node(2);
            BinaryTree.Node node3 = new BinaryTree.Node(3);
            BinaryTree.Node node4 = new BinaryTree.Node(4);
            BinaryTree.Node node5 = new BinaryTree.Node(3);
            BinaryTree.Node node6 = new BinaryTree.Node(4);
            root.LeftNode = node1;
            root.RightNode = node2;
            node1.LeftNode = node3;
            node1.RightNode = node4;
            node2.LeftNode = node5;
            node2.RightNode = node6;

            bool result = (new Question101()).IsSymmetric(root);
        }

        public bool IsSymmetric(BinaryTree.Node root)
        {
            if (root == null || (root.LeftNode == null && root.RightNode == null))
                return true;
            else
                return CheckSymmetric(root.LeftNode, root.RightNode);
        }

        private bool CheckSymmetric(BinaryTree.Node leftNode, BinaryTree.Node rightNode)
        {
            if (leftNode == null && rightNode == null)
                return true;
            else if (leftNode != null && rightNode != null && leftNode.Value == rightNode.Value)
                return CheckSymmetric(leftNode.LeftNode, rightNode.RightNode) && CheckSymmetric(leftNode.RightNode, rightNode.LeftNode);
            else
                return false;
        }
    }
}