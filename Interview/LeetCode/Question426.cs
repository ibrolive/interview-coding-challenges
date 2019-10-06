using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question426
    {
        public static void EntryPoint()
        {
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();

            node1.val = 1;
            node2.val = 2;
            node3.val = 3;
            node4.val = 4;
            node5.val = 5;

            node4.left = node2;
            node4.right = node5;
            node2.left = node1;
            node2.right = node3;

            (new Question426()).TreeToDoublyList(node4);
        }

        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
                return null;

            if (root.left == null && root.right == null)
            {
                root.left = root;
                root.right = root;

                return root;
            }

            Node leftPart = root.left != null ? TreeToDoublyList(root.left) : null,
                 rightPart = root.right != null ? TreeToDoublyList(root.right) : null,
                 tempNode = rightPart != null ? rightPart.left : null;

            if (leftPart != null)
            {
                root.left = leftPart.left;
                leftPart.left.right = root;
            }

            if (rightPart != null)
            {
                root.right = rightPart;
                rightPart.left = root;
            }

            if (leftPart != null && rightPart != null)
            {
                leftPart.left = tempNode;
                tempNode.right = leftPart;
            }
            else if (leftPart == null && rightPart != null)
            {
                root.left = tempNode;
                tempNode.right = root;
            }
            else if (rightPart == null && leftPart != null)
            {
                root.right = leftPart;
                leftPart.left = root;
            }

            return leftPart == null ? root : leftPart;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;

            public Node() { }
            public Node(int _val, Node _left, Node _right)
            {
                val = _val;
                left = _left;
                right = _right;
            }
        }
    }
}
