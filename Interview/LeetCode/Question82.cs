using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question82
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(1);
            Node node3 = new Node(2);

            node1.NextNode = node2;
            node2.NextNode = node3;

            (new Question82()).DeleteDuplicates(node1);
        }

        public Node DeleteDuplicates(Node head)
        {
            if (head == null || head.NextNode == null)
                return head;

            Node dummyNode = new Node(-1), tempNode1, tempNode2, tempNode3;
            dummyNode.NextNode = head;
            tempNode1 = dummyNode;
            tempNode2 = tempNode1.NextNode;
            tempNode3 = tempNode2.NextNode;

            while (tempNode3 != null)
            {
                if (tempNode2.Value == tempNode3.Value)
                {
                    while (tempNode3 != null && tempNode2.Value == tempNode3.Value)
                    {
                        tempNode2 = tempNode3;
                        tempNode3 = tempNode2.NextNode;
                    }

                    tempNode2.NextNode = null;
                    tempNode1.NextNode = tempNode3;
                }
                else
                    tempNode1 = tempNode1.NextNode;

                if (tempNode1 != null)
                    tempNode2 = tempNode1.NextNode;
                if (tempNode2 != null)
                    tempNode3 = tempNode2.NextNode;
                else
                    tempNode3 = null;
            }

            return dummyNode.NextNode;
        }
    }
}