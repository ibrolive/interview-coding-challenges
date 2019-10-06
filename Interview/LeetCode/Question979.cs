using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question979
    {
        private int _count = 0;

        public int DistributeCoins(TreeNode root)
        {
            DFS(root);

            return this._count;
        }

        public int DFS(TreeNode node)
        {
            if (node == null)
                return 0;

            int L = DFS(node.left);
            int R = DFS(node.right);

            this._count += Math.Abs(L) + Math.Abs(R);

            return node.val + L + R - 1;
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
