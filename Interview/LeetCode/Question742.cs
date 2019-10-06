using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question742
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(1),
                     node2 = new TreeNode(2),
                     node3 = new TreeNode(3),
                     node4 = new TreeNode(4),
                     node5 = new TreeNode(5),
                     node6 = new TreeNode(6);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node4.left = node5;
            node5.left = node6;

            (new Question742()).FindClosestLeaf(node1, 2);
        }

        private TreeNode _target = null;
        private Dictionary<int, List<TreeNode>> _adjacency = new Dictionary<int, List<TreeNode>>();

        public int FindClosestLeaf(TreeNode root, int k)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            ConvertToAdjacency(root, k);

            queue.Enqueue(_target);

            while (queue.Count > 0)
            {
                TreeNode temp = queue.Dequeue();
                List<TreeNode> tempList = _adjacency[temp.val];

                if (temp.left == null && temp.right == null)
                    return temp.val;

                foreach (var item in tempList)
                {
                    queue.Enqueue(item);
                    _adjacency[item.val].Remove(temp);
                }
            }

            return root.val;
        }

        private void ConvertToAdjacency(TreeNode node, int k)
        {
            if (node.val == k)
                _target = node;

            if (!_adjacency.ContainsKey(node.val))
                _adjacency.Add(node.val, new List<TreeNode>());

            if (node.left != null)
            {
                _adjacency[node.val].Add(node.left);

                if (!_adjacency.ContainsKey(node.left.val))
                    _adjacency.Add(node.left.val, new List<TreeNode>());

                _adjacency[node.left.val].Add(node);

                ConvertToAdjacency(node.left, k);
            }

            if (node.right != null)
            {
                _adjacency[node.val].Add(node.right);

                if (!_adjacency.ContainsKey(node.right.val))
                    _adjacency.Add(node.right.val, new List<TreeNode>());

                _adjacency[node.right.val].Add(node);

                ConvertToAdjacency(node.right, k);
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
