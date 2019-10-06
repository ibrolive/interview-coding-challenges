using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question958
    {
        public bool IsCompleteTree(TreeNode root)
        {
            List<AnnotationNode> nodes = new List<AnnotationNode>();
            AnnotationNode tempNode = null;
            int count = 0;

            nodes.Add(new AnnotationNode(root, 1));

            while (nodes.Count > count)
            {
                tempNode = nodes[count++];

                if (tempNode.Node.left != null)
                    nodes.Add(new AnnotationNode(tempNode.Node.left, tempNode.Position * 2));

                if (tempNode.Node.right != null)
                    nodes.Add(new AnnotationNode(tempNode.Node.right, tempNode.Position * 2 + 1));
            }

            return nodes[nodes.Count - 1].Position == nodes.Count;
        }

        public class AnnotationNode
        {
            public TreeNode Node = null;
            public int Position = 0;

            public AnnotationNode(TreeNode node, int position)
            {
                this.Node = node;
                this.Position = position;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
