using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question449
    {
        public static void EntryPoint()
        {
            Codec.TreeNode node1 = new Codec.TreeNode(37);
            Codec.TreeNode node2 = new Codec.TreeNode(41);
            Codec.TreeNode node3 = new Codec.TreeNode(44);
            Codec.TreeNode node4 = new Codec.TreeNode(24);
            Codec.TreeNode node5 = new Codec.TreeNode(39);
            Codec.TreeNode node6 = new Codec.TreeNode(42);
            Codec.TreeNode node7 = new Codec.TreeNode(48);
            Codec.TreeNode node8 = new Codec.TreeNode(1);

            node2.left = node1;
            node2.right = node3;
            node1.left = node4;
            node1.right = node5;
            node3.left = node6;
            node3.right = node7;
            node4.left = node8;

            Codec obj = new Codec();
            string output = obj.serialize(node2);
            Codec.TreeNode root = obj.deserialize(output);
        }

        // https://leetcode.com/problems/serialize-and-deserialize-bst/discuss/93168/Deserialize-from-preorder-and-computed-inorder-reusing-old-solution
        public class Codec
        {
            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                StringBuilder output = new StringBuilder();

                if (root != null)
                    PreOrderHelper(root, output);

                if (root != null && output[output.Length - 1] == '#')
                    output.Remove(output.Length - 1, 1);

                return output.ToString();
            }

            private void PreOrderHelper(TreeNode root, StringBuilder output)
            {
                output.Append(root.val + "#");

                if (root.left != null)
                    PreOrderHelper(root.left, output);

                if (root.right != null)
                    PreOrderHelper(root.right, output);
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (data == string.Empty)
                    return null;

                string[] temp = data.Split(new char[] { '#' });
                int[] preorder = new int[temp.Length],
                      inorder = new int[temp.Length];

                for (int i = 0; i < temp.Length; i++)
                    preorder[i] = Convert.ToInt32(temp[i]);

                Array.Copy(preorder, inorder, preorder.Length);

                Array.Sort(inorder);

                return RebuildTree(preorder.ToList<int>(), inorder.ToList<int>());
            }

            private TreeNode RebuildTree(List<int> preorder, List<int> inorder)
            {
                if (inorder.Count == 0)
                    return null;

                TreeNode root = new TreeNode(Convert.ToInt32(preorder[0]));
                int index = inorder.IndexOf(preorder[0]);
                List<int> preorderLeft = new List<int>(),
                          preorderRigth = new List<int>(),
                          inorderLeft = new List<int>(),
                          inorderRight = new List<int>();

                for (int i = 1; i < index + 1; i++)
                    preorderLeft.Add(preorder[i]);

                for (int i = index + 1; i < preorder.Count; i++)
                    preorderRigth.Add(preorder[i]);

                for (int i = 0; i < index; i++)
                    inorderLeft.Add(inorder[i]);

                for (int i = index + 1; i < inorder.Count; i++)
                    inorderRight.Add(inorder[i]);

                root.left = RebuildTree(preorderLeft, inorderLeft);
                root.right = RebuildTree(preorderRigth, inorderRight);

                return root;
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
}
