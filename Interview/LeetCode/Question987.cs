using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question987
    {
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            SortedList<int, List<int>> result = new SortedList<int, List<int>>();
            Queue<AnnotationNode> queue = new Queue<AnnotationNode>();
            int count = 0;

            queue.Enqueue(new AnnotationNode(root, 0, 0));

            while (queue.Count != 0)
            {
                count = queue.Count;
                Dictionary<int, SortedSet<int>> dictionary = new Dictionary<int, SortedSet<int>>();

                while (count-- > 0)
                {
                    AnnotationNode annotationNode = queue.Dequeue();

                    if (!dictionary.Keys.Contains(annotationNode.X))
                        dictionary.Add(annotationNode.X, new SortedSet<int>());

                    dictionary[annotationNode.X].Add(annotationNode.Node.val);

                    if (annotationNode.Node.left != null)
                        queue.Enqueue(new AnnotationNode(annotationNode.Node.left, annotationNode.X - 1, annotationNode.Y - 1));

                    if (annotationNode.Node.right != null)
                        queue.Enqueue(new AnnotationNode(annotationNode.Node.right, annotationNode.X + 1, annotationNode.Y - 1));
                }

                foreach (var item in dictionary)
                {
                    if (!result.Keys.Contains(item.Key))
                        result.Add(item.Key, new List<int>());

                    result[item.Key].AddRange(item.Value.ToList<int>());
                }
            }

            return result.Values.ToList<IList<int>>();
        }

        public class AnnotationNode
        {
            public int X = 0,
                       Y = 0;
            public TreeNode Node = null;

            public AnnotationNode(TreeNode node, int x, int y)
            {
                this.Node = node;
                this.X = x;
                this.Y = y;
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
