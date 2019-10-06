using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question106
    {
        public static void EntryPoint()
        {
            (new Question106()).BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            List<int> postorderList = new List<int>();

            foreach (var item in postorder)
                postorderList.Add(item);

            return Helper(inorder, postorderList);
        }

        private TreeNode Helper(int[] inorder, List<int> postorderList)
        {
            if (inorder.Length == 0)
                return null;

            TreeNode root = new TreeNode(postorderList[postorderList.Count - 1]);
            int index = 0;
            int[] leftInorder = null,
                  rightInorder = null;

            for (; index < inorder.Length && inorder[index] != root.val; index++) { }

            leftInorder = new int[index];
            Array.Copy(inorder, 0, leftInorder, 0, index);

            if (index > inorder.Length - 1)
                rightInorder = new int[0];
            else
            {
                rightInorder = new int[inorder.Length - index - 1];
                Array.Copy(inorder, index + 1, rightInorder, 0, inorder.Length - index - 1);
            }

            postorderList.RemoveAt(postorderList.Count - 1);

            root.right = Helper(rightInorder, postorderList);
            root.left = Helper(leftInorder, postorderList);

            return root;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }
    }
}
