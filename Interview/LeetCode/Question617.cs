using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question617
    {
        public static void EntryPoint()
        {
            TreeNode t1 = new TreeNode(1);
            TreeNode t2 = new TreeNode(1);

            (new Question617()).MergeTrees(t1, t2);
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            else if (t2 == null)
                return t1;

            TreeNode root = new TreeNode(t1.val + t2.val);

            root.left = MergeTrees(t1.left, t2.left);
            root.right = MergeTrees(t1.right, t2.right);

            return root;
        }
    }
}