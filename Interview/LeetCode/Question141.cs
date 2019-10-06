using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question141
    {
        public bool HasCycle(Node head)
        {
            Node slowPointer = head, fastPointer = head;

            while (fastPointer != null && fastPointer.NextNode != null)
            {
                slowPointer = slowPointer.NextNode;
                fastPointer = fastPointer.NextNode.NextNode;

                if (slowPointer == fastPointer)
                    return true;
            }

            return false;
        }
    }
}