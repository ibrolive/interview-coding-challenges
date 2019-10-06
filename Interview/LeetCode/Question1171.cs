using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1171
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            Dictionary<int, ListNode> dict1 = new Dictionary<int, ListNode>();
            Dictionary<ListNode, int> dict2 = new Dictionary<ListNode, int>();
            ListNode tempNode1 = head,
                     tempNode2;
            int sum = 0;

            while (tempNode1 != null)
            {
                sum += tempNode1.val;

                if (sum == 0)
                {
                    tempNode2 = head;

                    while (tempNode2 != tempNode1)
                    {
                        if (dict2.ContainsKey(tempNode2))
                            dict1.Remove(dict2[tempNode2]);

                        tempNode2 = tempNode2.next;
                    }

                    head = tempNode1.next;
                }
                else if (dict1.ContainsKey(sum))
                {
                    tempNode2 = dict1[sum].next;

                    while (tempNode2 != tempNode1)
                    {
                        if (dict2.ContainsKey(tempNode2))
                            dict1.Remove(dict2[tempNode2]);

                        tempNode2 = tempNode2.next;
                    }

                    dict1[sum].next = tempNode1.next;
                    tempNode1 = tempNode1.next;
                }
                else
                {
                    dict1.Add(sum, tempNode1);
                    dict2.Add(tempNode1, sum);

                    tempNode1 = tempNode1.next;
                }
            }

            return head;
        }
    }
}
