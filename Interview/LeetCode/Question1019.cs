using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1019
    {
        public static void EntryPoint()
        {
            ListNode node1 = new ListNode(2);
            ListNode node2 = new ListNode(7);
            ListNode node3 = new ListNode(4);
            ListNode node4 = new ListNode(3);
            ListNode node5 = new ListNode(5);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            (new Question1019()).NextLargerNodes(node1);
        }

        public int[] NextLargerNodes(ListNode head)
        {
            List<int> list = new List<int>();
            Stack<int> indexes = new Stack<int>();

            for (var curr = head; curr != null; curr = curr.next)
                list.Add(curr.val);

            int[] res = new int[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                while (indexes.Count != 0 && list[indexes.Peek()] < list[i])
                    res[indexes.Pop()] = list[i];

                indexes.Push(i);
            }

            return res;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
