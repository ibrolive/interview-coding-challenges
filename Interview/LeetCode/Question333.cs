using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question333
    {
        public static void EntryPoint()
        {
            //TreeNode node1 = new TreeNode(10);
            //TreeNode node2 = new TreeNode(5);
            //TreeNode node3 = new TreeNode(15);
            //TreeNode node4 = new TreeNode(1);
            //TreeNode node5 = new TreeNode(8);
            //TreeNode node6 = new TreeNode(7);

            //node1.left = node2;
            //node1.right = node3;
            //node2.left = node4;
            //node2.right = node5;
            //node3.right = node6;

            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(1);

            node1.left = node2;
            node2.left = node3;

            (new Question333()).LargestBSTSubtree(node1);
        }

        // https://www.youtube.com/watch?v=4fiDs7CCxkc
        public int LargestBSTSubtree(TreeNode root)
        {
            if (root == null)
                return 0;

            return Helper(root).Size;
        }

        private Result Helper(TreeNode root)
        {
            Result result = new Result(),
                   resultL = new Result(),
                   resultR = new Result();

            if (root.left == null && root.right == null)
            {
                result.Size = 1;
                result.Min = root.val;
                result.Max = root.val;

                return result;
            }

            if (root.left != null)
                resultL = Helper(root.left);

            if (root.right != null)
                resultR = Helper(root.right);

            if (resultL.IsBST && resultR.IsBST &&
                ((resultL.Size != 0 && resultL.Max < root.val) || resultL.Size == 0) &&
                ((resultR.Size != 0 && resultR.Min > root.val) || resultR.Size == 0))
            {
                result.Size = resultL.Size + resultR.Size + 1;
                result.Min = resultL.Size != 0 ? resultL.Min : root.val;
                result.Max = resultR.Size != 0 ? resultR.Max : root.val;
            }
            else
            {
                result.IsBST = false;
                result.Size = Math.Max(resultL.Size, resultR.Size);
                result.Min = 0;
                result.Max = 0;
            }

            return result;
        }

        public class Result
        {
            public bool IsBST = true;
            public int Size = 0;
            public int Min = 0;
            public int Max = 0;
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
