using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question160
    {
        public Node GetIntersectionNode(Node headA, Node headB)
        {
            if (headA == null || headB == null)
                return null;

            int lengthA = CheckLength(headA);
            int lengthB = CheckLength(headB);

            while (lengthA > lengthB)
            {
                headA = headA.NextNode;
                lengthA--;
            }

            while (lengthA < lengthB)
            {
                headB = headB.NextNode;
                lengthB--;
            }

            while (headA != headB)
            {
                headA = headA.NextNode;
                headB = headB.NextNode;
            }

            return headA;
        }

        private int CheckLength(Node head)
        {
            int length = 0;
            Node currentNode = head;

            while (currentNode != null)
            {
                length++;
                currentNode = currentNode.NextNode;
            }

            return length;
        }
    }
}