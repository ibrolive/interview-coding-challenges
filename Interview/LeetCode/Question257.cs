using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question257
    {
        public IList<string> BinaryTreePaths(BinaryTree.Node root)
        {
            List<string> result = new List<string>();

            if (root != null)
                ExtendPath(root, string.Empty, result);

            return result;
        }

        private void ExtendPath(BinaryTree.Node node, string currentPath, List<string> result)
        {
            currentPath += node.Value.ToString() + "->";

            if (node.LeftNode == null && node.RightNode == null)
                result.Add(currentPath.Substring(0, currentPath.Length - 2));

            if (node.LeftNode != null)
                ExtendPath(node.LeftNode, currentPath, result);

            if (node.RightNode != null)
                ExtendPath(node.RightNode, currentPath, result);
        }
    }
}