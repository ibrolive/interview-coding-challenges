using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question663
    {
        Stack<int> seen;

        public bool CheckEqualTree(TreeNode root)
        {
            seen = new Stack<int>();
            int total = Sum(root);

            seen.Pop();

            if (total % 2 == 0)
                foreach (var s in seen)
                    if (s == total / 2)
                        return true;

            return false;
        }

        public int Sum(TreeNode node)
        {
            if (node == null)
                return 0;

            seen.Push(Sum(node.left) + Sum(node.right) + node.val);

            return seen.Peek();
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
