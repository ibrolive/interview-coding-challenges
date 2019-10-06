using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question2
    {
        public static void EntryPoint()
        {
            Node l1 = new Node(1);
            Node l1a = new Node(8);
            l1.NextNode = l1a;
            Node l2 = new Node(0);

            (new Question2()).AddTwoNumbers(l1, l2);
        }

        public Node AddTwoNumbers(Node l1, Node l2)
        {
            int carrier = 0, tempResult = 0;
            Node dummyNode = new Node(-1), previousNode;
            previousNode = dummyNode;

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                    tempResult += l1.Value;

                if (l2 != null)
                    tempResult += l2.Value;

                if (carrier != 0)
                {
                    tempResult += carrier;
                    carrier = 0;
                }

                if (tempResult >= 10)
                {
                    tempResult = tempResult % 10;
                    carrier = 1;
                }

                previousNode.NextNode = new Node(tempResult);
                previousNode = previousNode.NextNode;

                tempResult = 0;
                if (l1 != null)
                    l1 = l1.NextNode;
                if (l2 != null)
                    l2 = l2.NextNode;
            }

            if (carrier > 0)
                previousNode.NextNode = new Node(1);

            return dummyNode.NextNode;
        }
    }
}