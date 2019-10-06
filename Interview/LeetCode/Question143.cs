using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question143
    {
        public void ReorderList(Node head)
        {
            if (head == null || head.NextNode == null)
                return;

            Node slow = head,
                 fast = head,
                 rightHead = null;

            while (fast.NextNode != null && fast.NextNode.NextNode != null)
            {
                slow = slow.NextNode;
                fast = fast.NextNode.NextNode;
            }

            rightHead = Reverse(slow.NextNode);

            slow.NextNode = null;

            Reorder(head, rightHead);
        }

        private Node Reverse(Node node)
        {
            Node node1 = null,
                 node2 = node,
                 node3 = null;

            if (node2 != null)
                node3 = node2.NextNode;

            while (node2 != null)
            {
                node2.NextNode = node1;

                node1 = node2;
                node2 = node3;

                if (node2 != null)
                    node3 = node2.NextNode;
            }

            return node1;
        }

        private Node Reorder(Node leftHead, Node rightHead)
        {
            Node node1 = leftHead,
                 node2 = rightHead,
                 node3 = node1.NextNode;

            while (node2 != null)
            {
                node1.NextNode = node2;

                node1 = node2;
                node2 = node3;
                node3 = node1.NextNode;
            }

            return leftHead;
        }
    }
}