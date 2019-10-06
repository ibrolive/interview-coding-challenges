using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question237
    {
        public void DeleteNode(Node node)
        {
            node.Value = node.NextNode.Value;
            node.NextNode = node.NextNode.NextNode;
        }
    }
}