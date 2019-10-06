using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question86
    {
        public static void EntryPoint()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(1);
            node1.NextNode = node2;

            (new Question86()).Partition(node1, 0);
        }

        public Node Partition(Node head, int x)
        {
            if (head == null)
                return head;

            Node lessDummy = new Node(-1),
                 lessCurrent = lessDummy,
                 greaterDummy = new Node(-1),
                 greaterCurrent = greaterDummy;

            while (head != null)
            {
                if (head.Value < x)
                {
                    lessCurrent.NextNode = head;
                    head = head.NextNode;
                    lessCurrent = lessCurrent.NextNode;
                    lessCurrent.NextNode = null;
                }
                else
                {
                    greaterCurrent.NextNode = head;
                    head = head.NextNode;
                    greaterCurrent = greaterCurrent.NextNode;
                    greaterCurrent.NextNode = null;
                }
            }

            lessCurrent.NextNode = greaterDummy.NextNode;

            return lessDummy.NextNode;
        }
    }
}