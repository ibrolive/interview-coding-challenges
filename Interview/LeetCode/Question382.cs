using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question382
    {

    }

    // https://en.wikipedia.org/wiki/Reservoir_sampling
    // http://blog.jobbole.com/42550/
    public class SolutionQuestion382
    {
        ListNode head;
        Random random;

        public SolutionQuestion382(ListNode head)
        {
            this.head = head;
            random = new Random();
        }

        public int GetRandom()
        {
            ListNode c = head;
            int result = c.val;
            for (int i = 1; c.next != null; i++)
            {
                c = c.next;
                if (random.Next(i + 1) == i)
                    result = c.val;
            }

            return result;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
