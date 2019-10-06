using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question116
    {
        // https://leetcode.com/problems/populating-next-right-pointers-in-each-node/discuss/37461/Java-solution-with-O(1)-memory+-O(n)-time
        public Node Connect(Node root)
        {
            Node mostLeft = root,
                 currentNode = null;

            while (mostLeft != null)
            {
                currentNode = mostLeft;

                while (currentNode != null)
                {
                    if (currentNode.left != null)
                        currentNode.left.next = currentNode.right;

                    if (currentNode.right != null && currentNode.next != null)
                        currentNode.right.next = currentNode.next.left;

                    currentNode = currentNode.next;
                }

                mostLeft = mostLeft.left;
            }

            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }
            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
