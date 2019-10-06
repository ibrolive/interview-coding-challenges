using Interview.Algorithm.Search;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interview.DataStructure
{
    class BSTTest
    {
        public static void EntryPoint()
        {
            BinarySearchTree bst = new BinarySearchTree();

            bst.Insert(10);
            bst.Insert(8);
            bst.Insert(30);
            bst.Insert(2);
            bst.Insert(15);

            Console.WriteLine(bst.ToString());
            Console.WriteLine(bst.Root.Value);

            Console.WriteLine(bst.Search(3) == null);
            Console.WriteLine(bst.Search(15).Value);

            bst.Delete(15);

            Console.WriteLine(bst.ToString());
            Console.WriteLine(bst.Root.Value);
        }
    }

    class BinarySearchTree
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        public Node Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int key)
        {
            Root = Insert(Root, key);
        }

        private Node Insert(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            if (key < root.Value)
                root.Left = Insert(root.Left, key);
            else if (key > root.Value)
                root.Right = Insert(root.Right, key);

            return root;
        }

        public void Delete(int key)
        {
            Root = Delete(Root, key);
        }

        private Node Delete(Node root, int key)
        {
            if (root == null)
                return root;

            if (key < root.Value)
                root.Left = Delete(root.Left, key);
            else if (key > root.Value)
                root.Right = Delete(root.Right, key);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root = MinValue(root.Right);
                root.Right = Delete(root.Right, root.Value);
            }

            return root;
        }

        private Node MinValue(Node root)
        {
            Node min = root;

            while (root.Left != null)
            {
                min = root.Left;
                root = root.Left;
            }

            return min;
        }

        public Node Search(int key)
        {
            return Search(Root, key);
        }

        private Node Search(Node node, int key)
        {
            if (node == null)
                return null;
            else if (node.Value == key)
                return node;
            else if (node.Value > key)
                return Search(node.Left, key);
            else
                return Search(node.Right, key);           
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            DFS(Root, builder);

            return builder.ToString();
        }

        private void DFS(Node root, StringBuilder result)
        {
            if (root != null)
            {
                DFS(root.Left, result);
                result.Append(root.Value + " ");
                DFS(root.Right, result);
            }
        }
    }
}
