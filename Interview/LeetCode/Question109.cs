using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question109
    {
        public static void EntryPoint()
        {
            ListNode node1 = new ListNode(-10);
            ListNode node2 = new ListNode(-3);
            ListNode node3 = new ListNode(0);
            ListNode node4 = new ListNode(5);
            ListNode node5 = new ListNode(9);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            TreeNode root = (new Question109()).SortedListToBST(node1);
        }

        // https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/discuss/194134/C++-recursion.
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;
            else if (head.next == null)
                return new TreeNode(head.val);

            TreeNode root = null;
            ListNode mid = SplitList(head);

            root = new TreeNode(mid.val);
            root.left = SortedListToBST(head);
            root.right = SortedListToBST(mid.next);

            return root;
        }

        private ListNode SplitList(ListNode head)
        {
            ListNode dummy = new ListNode(0),
                     slow = dummy,
                     fast = head.next,
                     mid = null;

            dummy.next = head;

            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next != null ? fast.next.next : null;
            }

            mid = slow.next;
            slow.next = null;

            return mid;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
