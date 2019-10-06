using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question430
    {
        public Node Flatten(Node head)
        {
            if (head != null)
                Helper(head);

            return head;
        }

        private void Helper(Node node)
        {
            if (node.next == null && node.child == null)
                return;

            Node lastNode = node.child,
                 nextNode = node.next;

            if (node.child != null)
            {
                Helper(node.child);

                node.next = node.child;
                node.next.prev = node;

                if (nextNode != null)
                {
                    while (lastNode.next != null)
                        lastNode = lastNode.next;

                    lastNode.next = nextNode;
                    nextNode.prev = lastNode;
                }

                node.child = null;
            }

            if (nextNode != null)
                Helper(nextNode);
        }

        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;

            public Node() { }
            public Node(int _val, Node _prev, Node _next, Node _child)
            {
                val = _val;
                prev = _prev;
                next = _next;
                child = _child;
            }
        }
    }
}
