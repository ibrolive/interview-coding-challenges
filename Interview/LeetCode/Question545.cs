using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question545
    {
        public static void EntryPoint()
        {
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);

            node1.right = node2;
            node2.left = node3;
            node2.right = node4;

            (new Question545()).BoundaryOfBinaryTree(node1);
        }

        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            IList<int> result = new List<int>();
            List<TreeNode> leftBoundary = new List<TreeNode>(),
                           leaves = new List<TreeNode>(),
                           rightBoundary = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode temp = null;

            if (root != null)
            {
                leftBoundary.Add(root);

                if (root.left != null)
                {
                    stack.Push(root.left);

                    while (stack.Count != 0)
                    {
                        temp = stack.Pop();

                        leftBoundary.Add(temp);

                        if (temp.left != null)
                            stack.Push(temp.left);
                        else if (temp.right != null)
                            stack.Push(temp.right);
                    }
                }

                stack.Push(root);

                while (stack.Count != 0)
                {
                    temp = stack.Pop();

                    if (temp.left == null && temp.right == null)
                        leaves.Add(temp);
                    else
                    {
                        if (temp.right != null)
                            stack.Push(temp.right);

                        if (temp.left != null)
                            stack.Push(temp.left);
                    }
                }

                if (root.right != null)
                {
                    stack.Push(root.right);

                    while (stack.Count != 0)
                    {
                        temp = stack.Pop();

                        rightBoundary.Add(temp);

                        if (temp.right != null)
                            stack.Push(temp.right);
                        else if (temp.left != null)
                            stack.Push(temp.left);
                    }
                }

                if (leftBoundary.Count > 0)
                    foreach (var item in leftBoundary)
                        result.Add(item.val);

                if (leaves.Count > 0)
                    foreach (var item in leaves)
                        if (!leftBoundary.Contains(item))
                            result.Add(item.val);

                if (rightBoundary.Count > 0)
                    for (int i = rightBoundary.Count - 1; i > -1; i--)
                        if (!leaves.Contains(rightBoundary[i]))
                            result.Add(rightBoundary[i].val);
            }

            return result;
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
