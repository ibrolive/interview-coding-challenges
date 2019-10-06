using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question19
    {
        public static void EntryPoint()
        {
            Node head = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            head.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;
            node4.NextNode = node5;

            (new Question19()).RemoveNthFromEnd(head, 2);
        }

        public Node RemoveNthFromEnd(Node head, int n)
        {
            if (head == null)
                return null;

            Node dummyNode = new Node(-1),
                     tempNode1 = dummyNode,
                     tempNode2 = dummyNode;
            tempNode1.NextNode = head;

            for (int i = 1; i <= n + 1; i++)
                tempNode2 = tempNode2.NextNode;

            while (tempNode2 != null)
            {
                tempNode1 = tempNode1.NextNode;
                tempNode2 = tempNode2.NextNode;
            }

            tempNode1.NextNode = tempNode1.NextNode.NextNode;

            return dummyNode.NextNode;
        }
    }
}