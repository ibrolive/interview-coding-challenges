using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question92
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            node1.NextNode = node2;
            node2.NextNode = node3;

            (new Question92()).ReverseBetween(node1, 2, 3);
        }

        public Node ReverseBetween(Node head, int m, int n)
        {
            if (head == null || head.NextNode == null)
                return head;

            Node dummyNode = new Node(-1),
                 tempTailInOriginal = null,
                 tempTailInReverse = null,
                 tempNode1 = null,
                 tempNode2 = null,
                 tempNode3 = null;

            dummyNode.NextNode = head;
            tempTailInOriginal = dummyNode;

            for (int i = 1; i < m; i++)
                tempTailInOriginal = tempTailInOriginal.NextNode;

            tempTailInReverse = tempTailInOriginal.NextNode;

            tempNode1 = tempTailInOriginal.NextNode;
            tempNode2 = tempNode1.NextNode;
            if (tempNode2 != null)
                tempNode3 = tempNode2.NextNode;

            for (int i = 1; i <= n - m; i++)
            {
                tempNode2.NextNode = tempNode1;
                tempNode1 = tempNode2;
                tempNode2 = tempNode3;
                if (tempNode2 != null)
                    tempNode3 = tempNode2.NextNode;
            }

            tempTailInOriginal.NextNode = tempNode1;
            tempTailInReverse.NextNode = tempNode2;

            return dummyNode.NextNode;
        }
    }
}