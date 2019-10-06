using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question429
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<Node> queue = new Queue<Node>();
            int levelCount = 0;
            Node tempNode = null;

            if (root != null)
            {
                queue.Enqueue(root);

                while (queue.Count != 0)
                {
                    levelCount = queue.Count;
                    result.Add(new List<int>());

                    while (levelCount > 0)
                    {
                        tempNode = queue.Dequeue();
                        levelCount--;

                        result[result.Count - 1].Add(tempNode.val);

                        if (tempNode.children != null)
                            foreach (var item in tempNode.children)
                                queue.Enqueue(item);
                    }
                }
            }

            return result;
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }
}
