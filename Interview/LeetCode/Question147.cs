using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question147
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(4);
            Node node2 = new Node(2);
            Node node3 = new Node(1);
            Node node4 = new Node(3);

            node1.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;

            (new Question147()).InsertionSortList(node1);
        }

        public Node InsertionSortList(Node head)
        {
            if (head == null || head.NextNode == null)
                return head;

            Node dummyNode = new Node(Int32.MinValue),
                 previousNode = head,
                 currentNode = head.NextNode,
                 startNode = dummyNode,
                 tempNode = null;

            dummyNode.NextNode = head;

            while (currentNode != null)
            {
                while (startNode != null && startNode.Value < currentNode.Value)
                    startNode = startNode.NextNode;

                if (startNode != currentNode)
                {
                    tempNode = new Node(currentNode.Value);
                    if (currentNode.NextNode != null)
                    {
                        currentNode.Value = currentNode.NextNode.Value;
                        currentNode.NextNode = currentNode.NextNode.NextNode;
                    }
                    else
                    {
                        while (previousNode.NextNode != currentNode)
                            previousNode = previousNode.NextNode;

                        previousNode.NextNode = null;
                        currentNode = null;
                    }
                    tempNode.NextNode = new Node(startNode.Value);
                    tempNode.NextNode.NextNode = startNode.NextNode;
                    startNode.Value = tempNode.Value;
                    startNode.NextNode = tempNode.NextNode;
                }
                else
                    currentNode = currentNode.NextNode;

                startNode = dummyNode;
            }

            return dummyNode.NextNode;
        }
    }
}
