using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question226
    {
        public BinaryTree.Node InvertTree(BinaryTree.Node root)
        {
            if (root == null)
                return root;

            BinaryTree.Node tempNode = root.LeftNode;
            root.LeftNode = root.RightNode;
            root.RightNode = tempNode;

            InvertTree(root.LeftNode);
            InvertTree(root.RightNode);

            return root;
        }
    }
}