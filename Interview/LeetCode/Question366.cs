using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question366
    {
        public static void EntryPoint()
        {
            BinaryTree.Node node1 = new BinaryTree.Node(1);
            BinaryTree.Node node2 = new BinaryTree.Node(2);
            BinaryTree.Node node3 = new BinaryTree.Node(3);
            BinaryTree.Node node4 = new BinaryTree.Node(4);
            BinaryTree.Node node5 = new BinaryTree.Node(5);
            BinaryTree.Node node6 = new BinaryTree.Node(6);
            BinaryTree.Node node7 = new BinaryTree.Node(7);

            node1.LeftNode = node2;
            node1.RightNode = node3;
            node2.LeftNode = node4;
            node2.RightNode = node5;
            node3.LeftNode = node6;
            node3.RightNode = node7;

            (new Question366()).FindLeaves(node1);
        }

        public IList<IList<int>> FindLeaves(BinaryTree.Node root)
        {
            IList<IList<int>> levels = new List<IList<int>>();

            Add(root, levels);

            return levels;
        }

        public int Add(BinaryTree.Node node, IList<IList<int>> levels)
        {
            if (node == null)
                return 0;
            int level = 1 + Math.Max(Add(node.LeftNode, levels), Add(node.RightNode, levels));

            if (levels.Count < level)
                levels.Add(new List<int>());

            levels[level - 1].Add(node.Value);

            return level;
        }
    }
}