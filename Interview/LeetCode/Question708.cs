using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question708
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(3);
            Node node2 = new Node(2);
            Node node3 = new Node(1);
            node1.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node1;

            (new Question708()).Insert(node1, 0);
        }

        public Node Insert(Node head, int insertVal)
        {
            Node dummyNode = new Node(Int32.MinValue),
                 currentNode = head,
                 minNode = new Node(Int32.MaxValue),
                 lastNode = null,
                 newNode = new Node(insertVal);

            if (head == null)
            {
                newNode.NextNode = newNode;
                return newNode;
            }

            do
            {
                if (currentNode.Value < minNode.Value)
                    minNode = currentNode;

                currentNode = currentNode.NextNode;
            }
            while (currentNode != head);

            do
            {
                if (currentNode.NextNode == minNode)
                {
                    lastNode = currentNode;
                    break;
                }

                currentNode = currentNode.NextNode;
            }
            while (currentNode != head);

            lastNode.NextNode = null;
            dummyNode.NextNode = minNode;
            currentNode = dummyNode;

            while (currentNode != null)
            {
                if ((currentNode.Value <= insertVal &&
                     currentNode.NextNode != null &&
                     currentNode.NextNode.Value > insertVal) ||
                    (currentNode.Value <= insertVal &&
                     currentNode.NextNode == null))
                {
                    newNode.NextNode = currentNode.NextNode;
                    currentNode.NextNode = newNode;

                    break;
                }
                else
                    currentNode = currentNode.NextNode;
            }

            currentNode = dummyNode.NextNode;

            while (currentNode.NextNode != null)
                currentNode = currentNode.NextNode;

            currentNode.NextNode = dummyNode.NextNode;

            return head;
        }
    }
}
