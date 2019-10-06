using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question369
    {
        public Node PlusOne(Node head)
        {
            int temp = PlusSingleNumber(head);

            if (temp == 1)
            {
                Node newHead = new Node(1);
                newHead.NextNode = head;

                return newHead;
            }

            return head;
        }

        private int PlusSingleNumber(Node node)
        {
            int temp = 0;

            if (node.NextNode == null)
                temp = node.Value + 1;
            else
                temp = node.Value + PlusSingleNumber(node.NextNode);

            node.Value = temp % 10;

            if (temp >= 10)
                return 1;
            else
                return 0;
        }
    }
}