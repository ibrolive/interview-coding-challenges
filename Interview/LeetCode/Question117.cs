using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question117
    {
        public Node Connect(Node root)
        {
            Node levelStart = root,
                 currentNode = null,
                 nextNode = null;

            while (levelStart != null)
            {
                currentNode = levelStart;

                while (currentNode != null)
                {
                    if (currentNode.left != null)
                    {
                        if (currentNode.right != null)
                            currentNode.left.next = currentNode.right;
                        else
                        {
                            nextNode = currentNode.next;

                            while (nextNode != null)
                                if (nextNode.left != null)
                                {
                                    currentNode.left.next = nextNode.left;

                                    break;
                                }
                                else if (nextNode.right != null)
                                {
                                    currentNode.left.next = nextNode.right;

                                    break;
                                }
                                else
                                    nextNode = nextNode.next;
                        }
                    }

                    if (currentNode.right != null)
                    {
                        nextNode = currentNode.next;

                        while (nextNode != null)
                            if (nextNode.left != null)
                            {
                                currentNode.right.next = nextNode.left;

                                break;
                            }
                            else if (nextNode.right != null)
                            {
                                currentNode.right.next = nextNode.right;

                                break;
                            }
                            else
                                nextNode = nextNode.next;
                    }

                    currentNode = currentNode.next;
                }

                if (levelStart.left != null)
                    levelStart = levelStart.left;
                else if (levelStart.right != null)
                    levelStart = levelStart.right;
                else if (levelStart.left == null && levelStart.right == null && levelStart.next != null)
                {
                    nextNode = levelStart.next;

                    while (nextNode != null)
                    {
                        if (nextNode.left != null)
                        {
                            levelStart = nextNode.left;

                            break;
                        }
                        else if (nextNode.right != null)
                        {
                            levelStart = nextNode.right;

                            break;
                        }
                        else
                            nextNode = nextNode.next;
                    }

                    if (nextNode == null)
                        levelStart = null;
                }
                else
                    levelStart = null;
            }

            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }
            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
