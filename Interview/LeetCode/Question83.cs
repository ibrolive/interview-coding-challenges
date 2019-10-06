using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question83
    {
        public Node DeleteDuplicates(Node head)
        {
            if (head == null || head.NextNode == null)
                return head;

            Node currentNode = head;

            while (currentNode.NextNode != null)
                if (currentNode.Value == currentNode.NextNode.Value)
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                else
                    currentNode = currentNode.NextNode;

            return head;
        }
    }
}