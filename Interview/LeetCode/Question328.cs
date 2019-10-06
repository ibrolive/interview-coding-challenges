using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question328
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(0);
            Node node2 = new Node(1);
            Node node3 = new Node(2);
            Node node4 = new Node(3);
            Node node5 = new Node(4);
            node1.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;
            node4.NextNode = node5;

            (new Question328()).OddEvenList(node1);
        }

        public Node OddEvenList(Node head)
        {
            if (head == null || head.NextNode == null || head.NextNode.NextNode == null)
                return head;

            Node oddNode = head, evenNode = head.NextNode, tempNode1 = evenNode.NextNode, tempNode2 = tempNode1.NextNode;
            int index = 3;

            evenNode.NextNode = null;

            while (tempNode1 != null)
            {
                if (index % 2 != 0)
                {
                    tempNode1.NextNode = oddNode.NextNode;
                    oddNode.NextNode = tempNode1;
                    oddNode = oddNode.NextNode;
                }
                else
                {
                    evenNode.NextNode = tempNode1;
                    evenNode = evenNode.NextNode;
                    evenNode.NextNode = null;
                }

                tempNode1 = tempNode2;
                if (tempNode1 != null)
                    tempNode2 = tempNode1.NextNode;

                index++;
            }

            return head;
        }
    }
}