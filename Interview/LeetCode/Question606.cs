using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question606
    {
        public string Tree2str(BinaryTree.Node t)
        {
            if (t == null)
                return string.Empty;
            else if (t.LeftNode == null && t.RightNode == null)
                return t.Value.ToString();

            StringBuilder result = new StringBuilder();

            result.Append(t.Value.ToString());
            if (t.RightNode != null)
            {
                ExtendResult(t.LeftNode, result);
                ExtendResult(t.RightNode, result);
            }
            else if (t.LeftNode != null)
                ExtendResult(t.LeftNode, result);

            return result.ToString();
        }

        private StringBuilder ExtendResult(BinaryTree.Node node, StringBuilder lastLevel)
        {
            lastLevel.Append("(");

            if (node != null)
            {
                lastLevel.Append(node.Value);

                if (node.RightNode != null)
                {
                    ExtendResult(node.LeftNode, lastLevel);
                    ExtendResult(node.RightNode, lastLevel);
                }
                else if (node.LeftNode != null)
                    ExtendResult(node.LeftNode, lastLevel);
            }

            lastLevel.Append(")");

            return lastLevel;
        }
    }
}