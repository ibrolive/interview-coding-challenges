using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question203
    {
        public Node RemoveElements(Node head, int val)
        {
            Node dummyNode = new Node(-1), currentNode;
            dummyNode.NextNode = head;
            currentNode = dummyNode;

            while (currentNode != null && currentNode.NextNode != null)
            {
                if (currentNode.NextNode.Value == val)
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                else
                    currentNode = currentNode.NextNode;
            }

            return dummyNode.NextNode;
        }
    }
}