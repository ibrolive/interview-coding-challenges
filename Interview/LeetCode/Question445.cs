using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question445
    {
        public Node AddTwoNumbers(Node l1, Node l2)
        {
            int l1Length = 0,
                l2Length = 0;

            Node tempNode = null,
                 templ1Head = new Node(-1),
                 templ2Head = new Node(-1);

            templ1Head.NextNode = l1;
            templ2Head.NextNode = l2;

            tempNode = l1;
            while (tempNode != null)
            {
                l1Length++;
                tempNode = tempNode.NextNode;
            }

            tempNode = l2;
            while (tempNode != null)
            {
                l2Length++;
                tempNode = tempNode.NextNode;
            }

            while (l1Length > l2Length)
            {
                tempNode = templ2Head.NextNode;
                templ2Head.NextNode = new Node(0);
                templ2Head.NextNode.NextNode = tempNode;
                l1Length--;
            }

            while (l1Length < l2Length)
            {
                tempNode = templ1Head.NextNode;
                templ1Head.NextNode = new Node(0);
                templ1Head.NextNode.NextNode = tempNode;
                l2Length--;
            }

            if (AddSingleNumber(templ1Head.NextNode, templ2Head.NextNode) == 1)
            {
                templ1Head.Value = 1;
                return templ1Head;
            }
            else
                return templ1Head.NextNode;
        }

        private int AddSingleNumber(Node node1, Node node2)
        {
            int temp = 0;

            if (node1.NextNode == null && node2.NextNode == null)
                temp = node1.Value + node2.Value;
            else
                temp = node1.Value + node2.Value + AddSingleNumber(node1.NextNode, node2.NextNode);

            if (temp >= 10)
            {
                node1.Value = temp % 10;
                return 1;
            }
            else
            {
                node1.Value = temp;
                return 0;
            }
        }
    }
}