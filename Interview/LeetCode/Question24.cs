using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question24
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            node1.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;

            (new Question24()).SwapPairs(node1);
        }

        public Node SwapPairs(Node head)
        {
            if (head == null || head.NextNode == null)
                return head;

            Node dummyNode = new Node(-1);
            dummyNode.NextNode = head;
            Node node1 = dummyNode, node2 = node1.NextNode, node3 = node2.NextNode, node4 = node3.NextNode;

            while (node3 != null)
            {
                node1.NextNode = node3;
                node2.NextNode = node4;
                node3.NextNode = node2;

                node1 = node2;
                if (node1 != null)
                    node2 = node1.NextNode;
                if (node2 != null && node2.NextNode != null)
                    node3 = node2.NextNode;
                else
                    node3 = null;
                if (node3 != null)
                    node4 = node3.NextNode;
            }

            return dummyNode.NextNode;
        }
    }
}