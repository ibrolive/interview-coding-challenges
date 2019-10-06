using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question21
    {
        public Node MergeTwoLists(Node l1, Node l2)
        {
            Node dummyNode = new Node(-1);
            Node currentNode = dummyNode;

            while (l1 != null && l2 != null)
            {
                if (l1.Value < l2.Value)
                {
                    currentNode.NextNode = l1;
                    l1 = l1.NextNode;
                }
                else if (l1.Value >= l2.Value)
                {
                    currentNode.NextNode = l2;
                    l2 = l2.NextNode;
                }

                currentNode = currentNode.NextNode;
            }

            if (l1 == null)
                currentNode.NextNode = l2;
            else if (l2 == null)
                currentNode.NextNode = l1;

            return dummyNode.NextNode;
        }
    }
}