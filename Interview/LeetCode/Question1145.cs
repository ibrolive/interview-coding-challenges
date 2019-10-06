using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1145
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        private int xChild = 0,
                    maxBranch = 0;

        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            DFS(root, false, x);

            if ((n - xChild) > n / 2 || maxBranch > n / 2)
                return true;
            else
                return false;
        }

        public int DFS(TreeNode node, bool metX, int x)
        {
            if (node != null)
            {
                if (node.val == x)
                    metX = true;

                if (metX)
                    xChild++;

                int left = DFS(node.left, metX, x),
                    right = DFS(node.right, metX, x);

                if (node.val == x)
                    maxBranch = Math.Max(left, right);

                return left + right + 1;
            }
            else
                return 0;
        }
    }
}
