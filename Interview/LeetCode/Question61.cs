using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question61
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            node1.NextNode = node2;
            node2.NextNode = node3;

            (new Question61()).RotateRight(node1, 2000000000);
        }

        public Node RotateRight(Node head, int k)
        {
            Node newHead = null,
                 fastNode = head,
                 slowNode = head,
                 lastNode = head;
            int counter = 1,
                length = 1,
                index = k;

            while (lastNode != null && lastNode.NextNode != null)
            {
                length++;
                lastNode = lastNode.NextNode;
            }
            index = k % length;

            if (k == 0 || head == null || head.NextNode == null)
                return head;

            index++;

            while (counter <= index)
            {
                fastNode = fastNode.NextNode;
                counter++;
            }

            while (fastNode != null)
            {
                slowNode = slowNode.NextNode;
                fastNode = fastNode.NextNode;
            }

            newHead = slowNode.NextNode;
            slowNode.NextNode = null;
            lastNode.NextNode = head;

            return newHead;
        }
    }
}