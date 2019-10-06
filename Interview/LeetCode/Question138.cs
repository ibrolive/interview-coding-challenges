using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question138
    {
        public class RandomListNode
        {
            public int label;
            public RandomListNode next, random;
            public RandomListNode(int x) { this.label = x; }
        };

        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
                return null;

            RandomListNode currentNode = head, tempNode = null, newHeader = null, copiedCurrentNode = null;

            while (currentNode != null)
            {
                tempNode = new RandomListNode(currentNode.label);
                tempNode.next = currentNode.next;
                currentNode.next = tempNode;

                currentNode = currentNode.next.next;
            }

            currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.random != null)
                    currentNode.next.random = currentNode.random.next;

                currentNode = currentNode.next.next;
            }

            newHeader = head.next;
            currentNode = head;
            copiedCurrentNode = newHeader;

            while (currentNode != null)
            {
                currentNode.next = currentNode.next.next;
                currentNode = currentNode.next;

                if (copiedCurrentNode.next != null)
                {
                    copiedCurrentNode.next = copiedCurrentNode.next.next;
                    copiedCurrentNode = copiedCurrentNode.next;
                }
            }

            return newHeader;
        }
    }
}