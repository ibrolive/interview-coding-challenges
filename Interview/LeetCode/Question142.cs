using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question142
    {
        public Node DetectCycle(Node head)
        {
            Node slowPointer = head, fastPointer = head, detectPointer = head, cyclePointer = null;

            while (fastPointer != null && fastPointer.NextNode != null)
            {
                slowPointer = slowPointer.NextNode;
                fastPointer = fastPointer.NextNode.NextNode;

                if (slowPointer == fastPointer)
                {
                    cyclePointer = slowPointer;
                    break;
                }
            }

            if (cyclePointer == null)
                return null;

            while (detectPointer != cyclePointer)
            {
                detectPointer = detectPointer.NextNode;
                cyclePointer = cyclePointer.NextNode;
            }

            return cyclePointer;
        }
    }
}
