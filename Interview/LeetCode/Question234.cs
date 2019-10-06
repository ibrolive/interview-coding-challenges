using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question234
    {
        public bool IsPalindrome(Node head)
        {
            if (head == null || head.NextNode == null)
                return true;

            Node slow = head,
                     fast = head,
                     rightHalfHead = null;

            while (fast.NextNode != null && fast.NextNode.NextNode != null)
            {
                fast = fast.NextNode.NextNode;
                slow = slow.NextNode;
            }

            rightHalfHead = Reverse(slow.NextNode);
            slow.NextNode = null;

            while (rightHalfHead != null)
            {
                if (head.Value != rightHalfHead.Value)
                    return false;

                head = head.NextNode;
                rightHalfHead = rightHalfHead.NextNode;
            }

            return true;
        }

        private Node Reverse(Node head)
        {
            Node node1 = null,
                 node2 = head,
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
    }
}