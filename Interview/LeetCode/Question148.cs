using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question148
    {
        public static void EntryPoint()
        {
            ListNode node1 = new ListNode(4);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(1);
            ListNode node4 = new ListNode(3);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;

            //ListNode node1 = new ListNode(-1);
            //ListNode node2 = new ListNode(5);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(4);
            //ListNode node5 = new ListNode(0);
            //node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;

            (new Question148()).SortList(node1);
        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode slow = head,
                     fast = head.next.next,
                     mid = null,
                     left = head,
                     right = null;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            mid = slow.next;
            slow.next = null;

            left = SortList(head);
            right = SortList(mid);

            return Merge(left, right);
        }

        private ListNode Merge(ListNode left, ListNode right)
        {
            ListNode dummy = new ListNode(0),
                     currentNode = dummy;

            while (left != null && right != null)
            {
                if (left.val <= right.val)
                {
                    currentNode.next = left;
                    left = left.next;
                }
                else
                {
                    currentNode.next = right;
                    right = right.next;
                }

                currentNode = currentNode.next;
            }

            if (left != null)
                currentNode.next = left;

            if (right != null)
                currentNode.next = right;

            return dummy.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
