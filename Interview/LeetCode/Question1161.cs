using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1161
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public int MaxLevelSum(TreeNode root)
        {
            int currentLevel = 1,
                level = Int32.MinValue,
                max = Int32.MinValue;
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int current = 0,
                    count = queue.Count;
                TreeNode node = null;

                while (count-- > 0)
                {
                    node = queue.Dequeue();

                    current += node.val;

                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                if (max < current)
                {
                    level = currentLevel;
                    max = current;
                }

                currentLevel++;
            }

            return level;
        }
    }
}
