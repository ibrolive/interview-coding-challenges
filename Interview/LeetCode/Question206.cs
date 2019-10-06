using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question206
    {
        public Node ReverseList(Node head)
        {
            if (head == null || head.NextNode == null)
                return head;

            Node node1 = head, node2 = node1.NextNode, node3 = node2.NextNode;

            head.NextNode = null;

            while (node2 != null)
            {
                node2.NextNode = node1;

                node1 = node2;
                node2 = node3;
                if (node3 != null)
                    node3 = node3.NextNode;
            }

            return node1;
        }
    }
}