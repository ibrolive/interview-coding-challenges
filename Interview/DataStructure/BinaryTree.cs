using System;
using System.Collections.Generic;

namespace Interview.DataStructure
{
    class BinaryTreeTest
    {
        public static void Entry()
        {
            //BinaryTree.Node LCA = null;
            //int[] arrayTree = { 1, 2, 3, 4, 5, 6, -1, 8, -1, 10, 11 };
            //int[] arrayTree = { 1, 2, -1, 3, -1, -1, -1, 4, -1 };
            //int[] arrayTree = { 1, -1, 2, -1, -1, -1, 3, -1, -1, -1, -1, -1, -1, -1, 4 };
            //int[] arrayTree = { 1, 2, 3, 4, 5, -1, 7, -1, -1, 8, -1 };
            //int[] arrayTree = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //int[] arrayTree = { 1 };
            //int[] arrayTree = { 1, 2, 2, 3, 4, 4, 9, -1, -1, 5, -1, -1, 6 };
            int[] arrayTree = { 1, 2 };
            //BinaryTree tree = new BinaryTree();
            BinaryTree tree = new BinaryTree(arrayTree);
            //Stack<BinaryTree.Node> path = null;

            //tree.Root = BinaryTree.Rebuild(new int[] { 1, 2, 4, 8, 5, 10, 11, 3, 6 },
            //                               new int[] { 8, 4, 2, 10, 5, 11, 1, 6, 3 });

            if (!tree.IsEmpty)
            {
                //tree.BFPrintByQueue();
                //tree.BFPrintByList();

                //tree.DLRByNonRecursion1();
                //tree.DLRByNonRecursion2();
                //tree.DLRByNonRecursion3();
                tree.LRDByNonRecursion1();
                //tree.LRDByNonRecursion2();
                //tree.LDRByNonRecursion1();
                //tree.LDRByNonRecursion2();

                //path = tree.FindPathFromRoot(new BinaryTree.Node(19));
                //if (path != null)
                //{
                //    Console.WriteLine("There is a path.");

                //    foreach (var item in path)
                //        Console.WriteLine(item.Value);
                //}
                //else
                //    Console.WriteLine("There is no path.");

                //LCA = tree.FindLCA(new BinaryTree.Node(6), new BinaryTree.Node(5));
                //if (LCA != null)
                //    Console.WriteLine("The least common ancestor is {0}", LCA.Value);
                //else
                //    Console.WriteLine("There is no least common ancestor.");

                //path = tree.FindPathBetweenNodes(new BinaryTree.Node(6), new BinaryTree.Node(2));
                //if (path != null)
                //{
                //    Console.WriteLine("There is a path.");

                //    foreach (var item in path)
                //        Console.WriteLine(item.Value);
                //}
                //else
                //    Console.WriteLine("There is no path.");

                //tree.BFPrintByQueue();
                //tree.TurnMirror();
                //tree.BFPrintByQueue();

                //tree.FindMaxDistance();

                //tree.CheckCompleteBTree();

                //tree.CheckAVL();

                //tree.FindPathMatchingInput(131);
            }
        }
    }

    class BinaryTree
    {
        public class Node
        {
            public int Value { get; set; }
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }

        private const int EMPTY_NODE = -1;

        public Node Root { get; set; }
        public bool IsEmpty
        {
            get
            {
                if (Root != null)
                    return false;
                return true;
            }
        }

        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(int[] arrayTree)
        {
            if (arrayTree == null)
            {
                Console.WriteLine("Wrong input!");
                return;
            }
            if (arrayTree.Length == 0)
            {
                Console.WriteLine("Wrong input!");
                return;
            }

            Root = new Node(arrayTree[0]);
            ConvertTreeStorage(arrayTree, Root, 1);
        }

        // DLR
        private void ConvertTreeStorage(int[] arrayTree, Node currentNode, int nodeSequence)
        {
            if (nodeSequence * 2 <= arrayTree.Length && nodeSequence * 2 + 1 <= arrayTree.Length)            
            {
                if (arrayTree[nodeSequence * 2 - 1] != EMPTY_NODE)
                    currentNode.LeftNode = new Node(arrayTree[nodeSequence * 2 - 1]);
                if (arrayTree[nodeSequence * 2] != EMPTY_NODE)
                    currentNode.RightNode = new Node(arrayTree[nodeSequence * 2]);

                if (currentNode.LeftNode != null)
                    ConvertTreeStorage(arrayTree, currentNode.LeftNode, nodeSequence * 2);
                if (currentNode.RightNode != null)
                    ConvertTreeStorage(arrayTree, currentNode.RightNode, nodeSequence * 2 + 1);
            }
        }

        public void BFPrintByQueue()
        {
            int lastPosition = 0;
            Node currentNode = null;
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(Root);
            lastPosition = queue.Count;

            while (queue.Count != 0)
            {
                currentNode = queue.Dequeue();
                Console.Write(currentNode.Value);
                lastPosition--;

                if (currentNode.LeftNode != null)
                    queue.Enqueue(currentNode.LeftNode);
                if (currentNode.RightNode != null)
                    queue.Enqueue(currentNode.RightNode);

                if (lastPosition == 0)
                {
                    Console.WriteLine(string.Empty);
                    lastPosition = queue.Count;
                }
            }
        }

        public void BFPrintByList()
        {
            int lastPosition = 0, totalVolume = 0;
            List<Node> list = new List<Node>();

            list.Add(Root);
            totalVolume = list.Count - 1;

            while (lastPosition <= totalVolume)
            {
                Console.Write(list[lastPosition].Value);
                if (list[lastPosition].LeftNode != null)
                    list.Add(list[lastPosition].LeftNode);
                if (list[lastPosition].RightNode != null)
                    list.Add(list[lastPosition].RightNode);

                if (lastPosition == totalVolume)
                {
                    Console.WriteLine(string.Empty);
                    totalVolume = list.Count - 1;
                }

                lastPosition++;
            }
        }

        public Stack<Node> FindPathFromRoot(Node target)
        {
            Node topInStack = null;
            Stack<Node> stack = new Stack<Node>();

            stack.Push(Root);

            while (stack.Count != 0)
            {
                if (stack.Peek().Value == target.Value)
                    return stack;

                if (stack.Peek().LeftNode != null)
                {
                    stack.Push(stack.Peek().LeftNode);
                    continue;
                }
                else if (stack.Peek().RightNode != null)
                {
                    stack.Push(stack.Peek().RightNode);
                    continue;
                }
                else
                {
                    topInStack = stack.Pop();

                    while (stack.Count != 0 && (topInStack == stack.Peek().RightNode || stack.Peek().RightNode == null))
                        topInStack = stack.Pop();

                    if (stack.Count != 0 && stack.Peek().RightNode != null)
                        stack.Push(stack.Peek().RightNode);
                }
            }

            return null;
        }

        public Node FindLCA(Node nodeA, Node nodeB)
        {
            Stack<Node> pathFromRootToNodeA = FindPathFromRoot(nodeA);
            Stack<Node> pathFromRootToNodeB = FindPathFromRoot(nodeB);
            Node topInStack = null;
            int temp = 0;

            if (pathFromRootToNodeA == null)
                return null;
            else if (pathFromRootToNodeB == null)
                return null;

            if (pathFromRootToNodeA.Count > pathFromRootToNodeB.Count)
            {
                temp = pathFromRootToNodeA.Count - pathFromRootToNodeB.Count;

                for (int i = 1; i <= temp; i++)
                {
                    pathFromRootToNodeA.Pop();
                }
            }
            else if (pathFromRootToNodeA.Count < pathFromRootToNodeB.Count)
            {
                temp = pathFromRootToNodeB.Count - pathFromRootToNodeA.Count;

                for (int i = 1; i <= temp; i++)
                {
                    pathFromRootToNodeB.Pop();
                }
            }

            while (pathFromRootToNodeA.Count != 0 && pathFromRootToNodeB.Count != 0)
            {
                topInStack = pathFromRootToNodeA.Peek();

                if (pathFromRootToNodeA.Pop() == pathFromRootToNodeB.Pop())
                    return topInStack;
            }

            return null;
        }

        public Stack<Node> FindPathBetweenNodes(Node start, Node end)
        {
            Stack<Node> pathFromRootToStart = FindPathFromRoot(start);
            Stack<Node> pathFromRootToEnd = FindPathFromRoot(end);
            Stack<Node> pathFromStartToLCA = new Stack<Node>();
            Stack<Node> pathFromEndToLCA = new Stack<Node>();
            Node topInStack1 = null;
            Node topInStack2 = null;
            int temp = 0;

            if (pathFromRootToStart == null)
                return null;
            else if (pathFromRootToEnd == null)
                return null;

            if (pathFromRootToStart.Count > pathFromRootToEnd.Count)
            {
                temp = pathFromRootToStart.Count - pathFromRootToEnd.Count;

                for (int i = 1; i <= temp; i++)
                {
                    pathFromStartToLCA.Push(pathFromRootToStart.Pop());
                }
            }
            else if (pathFromRootToStart.Count < pathFromRootToEnd.Count)
            {
                temp = pathFromRootToEnd.Count - pathFromRootToStart.Count;

                for (int i = 1; i <= temp; i++)
                {
                    pathFromEndToLCA.Push(pathFromRootToEnd.Pop());
                }
            }

            while (pathFromRootToStart.Count != 0 && pathFromRootToEnd.Count != 0)
            {
                topInStack1 = pathFromRootToStart.Pop();
                topInStack2 = pathFromRootToEnd.Pop();
                pathFromStartToLCA.Push(topInStack1);
                pathFromEndToLCA.Push(topInStack2);

                if (topInStack1 == topInStack2)
                {
                    pathFromEndToLCA.Pop();

                    while (pathFromEndToLCA.Count != 0)
                        pathFromStartToLCA.Push(pathFromEndToLCA.Pop());

                    return pathFromStartToLCA;
                }
            }

            return null;
        }

        public void FindPathMatchingInput(int input)
        {
            int currentSum = 0;
            Node topInStack = null;
            Stack<Node> stack = new Stack<Node>();

            stack.Push(Root);
            currentSum = Root.Value;

            while (stack.Count != 0)
            {
                if (stack.Peek().LeftNode != null &&
                    stack.Peek().LeftNode.Value <= input &&
                    stack.Peek().LeftNode.Value + currentSum <= input)
                {
                    stack.Push(stack.Peek().LeftNode);
                    currentSum += stack.Peek().Value;

                    continue;
                }
                else if (stack.Peek().RightNode != null &&
                         stack.Peek().RightNode.Value <= input &&
                         stack.Peek().RightNode.Value + currentSum <= input)
                {
                    stack.Push(stack.Peek().RightNode);
                    currentSum += stack.Peek().Value;

                    continue;
                }
                else
                {
                    if (currentSum == input)
                        foreach (var item in stack)
                            Console.WriteLine(item.Value);

                    topInStack = stack.Pop();
                    currentSum -= topInStack.Value;

                    while (stack.Count != 0 && (stack.Peek().RightNode == topInStack ||
                                                stack.Peek().RightNode == null ||
                                                stack.Peek().RightNode.Value > input ||
                                                stack.Peek().RightNode.Value + currentSum > input))
                    {
                        topInStack = stack.Pop();
                        currentSum -= topInStack.Value;
                    }

                    if (stack.Count != 0)
                    {
                        stack.Push(stack.Peek().RightNode);
                        currentSum += stack.Peek().Value;
                    }
                }
            }

            Console.WriteLine("There is no such path.");
        }

        public void DLRByNonRecursion1()
        {
            Stack<Node> stack = new Stack<Node>();
            Node topInStack = null;

            stack.Push(Root);

            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Peek().Value);

                if (stack.Peek().LeftNode != null)
                {
                    stack.Push(stack.Peek().LeftNode);
                    continue;
                }
                else if (stack.Peek().RightNode != null)
                {
                    stack.Push(stack.Peek().RightNode);
                    continue;
                }
                else
                {
                    topInStack = stack.Pop();

                    while (stack.Count != 0 && (stack.Peek().RightNode == topInStack || stack.Peek().RightNode == null))
                        topInStack = stack.Pop();

                    if (stack.Count != 0 && stack.Peek().RightNode != null)
                        stack.Push(stack.Peek().RightNode);
                }
            }
        }

        public void DLRByNonRecursion2()
        {
            Stack<Node> stack = new Stack<Node>();
            Node topInStack = null;

            stack.Push(Root);

            while (stack.Count != 0)
            {
                topInStack = stack.Pop();
                Console.WriteLine(topInStack.Value);

                if (topInStack.RightNode != null)
                    stack.Push(topInStack.RightNode);
                if (topInStack.LeftNode != null)
                    stack.Push(topInStack.LeftNode);
            }
        }

        public void DLRByNonRecursion3()
        {
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = Root;

            while (currentNode != null || stack.Count != 0)
            {
                if (currentNode != null)
                {
                    Console.WriteLine(currentNode.Value);

                    stack.Push(currentNode);
                    currentNode = currentNode.LeftNode;
                }
                else
                    currentNode = stack.Pop().RightNode;
            }
        }

        public void LRDByNonRecursion1()
        {
            Stack<Node> stack = new Stack<Node>();
            Node topInStack = null;

            stack.Push(Root);

            while (stack.Count != 0)
            {
                if (stack.Peek().LeftNode != null)
                {
                    stack.Push(stack.Peek().LeftNode);
                    continue;
                }
                else if (stack.Peek().RightNode != null)
                {
                    stack.Push(stack.Peek().RightNode);
                    continue;
                }
                else
                {
                    topInStack = stack.Pop();
                    Console.WriteLine(topInStack.Value);

                    while (stack.Count != 0 && (topInStack == stack.Peek().RightNode || stack.Peek().RightNode == null))
                    {
                        topInStack = stack.Pop();
                        Console.WriteLine(topInStack.Value);
                    }

                    if (stack.Count != 0 && stack.Peek().RightNode != null)
                        stack.Push(stack.Peek().RightNode);
                }
            }
        }

        public void LRDByNonRecursion2()
        {
            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            Node topInStack = null;

            stack1.Push(Root);

            while (stack1.Count != 0)
            {
                topInStack = stack1.Pop();

                stack2.Push(topInStack);

                if (topInStack.LeftNode != null)
                    stack1.Push(topInStack.LeftNode);
                if (topInStack.RightNode != null)
                    stack1.Push(topInStack.RightNode);
            }

            while (stack2.Count != 0)
                Console.WriteLine(stack2.Pop().Value);
        }

        public void LDRByNonRecursion1()
        {
            Stack<Node> stack = new Stack<Node>();
            Node topInStack = null;

            stack.Push(Root);

            while (stack.Count != 0)
            {
                if (stack.Peek().LeftNode != null)
                {
                    stack.Push(stack.Peek().LeftNode);
                    continue;
                }
                else if (stack.Peek().RightNode != null)
                {
                    stack.Push(stack.Peek().RightNode);
                    continue;
                }
                else
                {
                    topInStack = stack.Pop();
                    Console.WriteLine(topInStack.Value);

                    while (stack.Count != 0 && (stack.Peek().RightNode == topInStack || stack.Peek().RightNode == null))
                    {
                        if (stack.Peek().RightNode == null)
                            Console.WriteLine(stack.Peek().Value);

                        topInStack = stack.Pop();
                    }

                    if (stack.Count != 0 && stack.Peek().RightNode != null)
                    {
                        Console.WriteLine(stack.Peek().Value);
                        stack.Push(stack.Peek().RightNode);
                    }
                }
            }
        }

        public void LDRByNonRecursion2()
        {
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = Root;

            while (currentNode != null || stack.Count != 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftNode;
                }

                if (stack.Count != 0)
                {
                    currentNode = stack.Pop();
                    Console.WriteLine(currentNode.Value);
                    currentNode = currentNode.RightNode;
                }
            }
        }

        public void TurnMirror()
        {
            Queue<Node> queue = new Queue<Node>();
            Node currentNode = null;
            Node tempNode = null;

            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                currentNode = queue.Dequeue();

                tempNode = currentNode.LeftNode;
                currentNode.LeftNode = currentNode.RightNode;
                currentNode.RightNode = tempNode;

                if (currentNode.LeftNode != null)
                    queue.Enqueue(currentNode.LeftNode);
                if (currentNode.RightNode != null)
                    queue.Enqueue(currentNode.RightNode);
            }
        }

        public static Node Rebuild(int[] DLR, int[] LDR)
        {
            int currentPosition = 0;
            Node currentNode = null;
            Stack<Node> stack = new Stack<Node>();
            bool[] checkedLDRNodes = new bool[DLR.Length];

            for (int i = 0; i < DLR.Length; i++)
            {
                stack.Push(new Node(DLR[i]));

                for (int j = 0; j < LDR.Length; j++)
                {
                    if (stack.Peek().Value == LDR[j])
                    {
                        checkedLDRNodes[j] = true;
                        currentPosition = j;

                        break;
                    }
                }

                while ((currentPosition - 1 < 0 && checkedLDRNodes[currentPosition + 1]) ||
                       (checkedLDRNodes[currentPosition - 1] && currentPosition + 1 == LDR.Length) ||
                       checkedLDRNodes[currentPosition - 1] && checkedLDRNodes[currentPosition + 1])
                {
                    currentNode = stack.Pop();

                    if (stack.Count != 0)
                    {
                        if (stack.Peek().LeftNode == null)
                            stack.Peek().LeftNode = currentNode;
                        else if (stack.Peek().RightNode == null)
                            stack.Peek().RightNode = currentNode;

                        for (int j = 0; j < LDR.Length; j++)
                        {
                            if (stack.Peek().Value == LDR[j])
                            {
                                currentPosition = j;
                                break;
                            }
                        }
                    }
                    else
                        break;
                }
            }

            return currentNode;
        }

        public void FindMaxDistance()
        {
            int currentMaxDistance = 0;
            int leftMaxDistance = 0;
            int rightMaxDistance = 0;
            Node topInStack = null;
            Stack<Node> stackNodes = new Stack<Node>();
            Stack<int> stackLeftMaxDistance = new Stack<int>();
            Stack<int> stackRightMaxDistance = new Stack<int>();

            stackNodes.Push(Root);
            stackLeftMaxDistance.Push(0);
            stackRightMaxDistance.Push(0);

            while (stackNodes.Count != 0)
            {
                if (stackNodes.Peek().LeftNode != null)
                {
                    stackNodes.Push(stackNodes.Peek().LeftNode);
                    stackLeftMaxDistance.Push(0);
                    stackRightMaxDistance.Push(0);

                    continue;
                }
                else if (stackNodes.Peek().RightNode != null)
                {
                    stackNodes.Push(stackNodes.Peek().RightNode);
                    stackLeftMaxDistance.Push(0);
                    stackRightMaxDistance.Push(0);

                    continue;
                }
                else
                {
                    topInStack = stackNodes.Pop();
                    leftMaxDistance = stackLeftMaxDistance.Pop();
                    rightMaxDistance = stackRightMaxDistance.Pop();

                    if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().LeftNode)
                    {
                        if (leftMaxDistance >= rightMaxDistance)
                            stackLeftMaxDistance.Push(stackLeftMaxDistance.Pop() + leftMaxDistance + 1);
                        else
                            stackLeftMaxDistance.Push(stackLeftMaxDistance.Pop() + rightMaxDistance + 1);
                    }
                    else if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().RightNode)
                    {
                        if (leftMaxDistance >= rightMaxDistance)
                            stackRightMaxDistance.Push(stackRightMaxDistance.Pop() + leftMaxDistance + 1);
                        else
                            stackRightMaxDistance.Push(stackRightMaxDistance.Pop() + rightMaxDistance + 1);
                    }

                    while (stackNodes.Count != 0 && (stackNodes.Peek().RightNode == topInStack || stackNodes.Peek().RightNode == null))
                    {
                        topInStack = stackNodes.Pop();
                        leftMaxDistance = stackLeftMaxDistance.Pop();
                        rightMaxDistance = stackRightMaxDistance.Pop();

                        if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().LeftNode)
                        {
                            if (leftMaxDistance >= rightMaxDistance)
                                stackLeftMaxDistance.Push(stackLeftMaxDistance.Pop() + leftMaxDistance + 1);
                            else
                                stackLeftMaxDistance.Push(stackLeftMaxDistance.Pop() + rightMaxDistance + 1);
                        }
                        else if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().RightNode)
                        {
                            if (leftMaxDistance >= rightMaxDistance)
                                stackRightMaxDistance.Push(stackRightMaxDistance.Pop() + leftMaxDistance + 1);
                            else
                                stackRightMaxDistance.Push(stackRightMaxDistance.Pop() + rightMaxDistance + 1);
                        }

                        if (leftMaxDistance + rightMaxDistance > currentMaxDistance)
                            currentMaxDistance = leftMaxDistance + rightMaxDistance;
                    }

                    if (stackNodes.Count != 0 && stackNodes.Peek().RightNode != null)
                    {
                        stackNodes.Push(stackNodes.Peek().RightNode);
                        stackLeftMaxDistance.Push(0);
                        stackRightMaxDistance.Push(0);
                    }
                }
            }

            Console.WriteLine(currentMaxDistance);
        }

        public void CheckAVL()
        {
            int leftHeight = 0;
            int rightHeight = 0;
            Node topInStack = null;
            Stack<Node> stackNodes = new Stack<Node>();
            Stack<int> stackLeftHeight = new Stack<int>();
            Stack<int> stackRightHeight = new Stack<int>();

            stackNodes.Push(Root);
            stackLeftHeight.Push(0);
            stackRightHeight.Push(0);

            while (stackNodes.Count != 0)
            {
                if (stackNodes.Peek().LeftNode != null)
                {
                    stackNodes.Push(stackNodes.Peek().LeftNode);
                    stackLeftHeight.Push(0);
                    stackRightHeight.Push(0);

                    continue;
                }
                else if (stackNodes.Peek().RightNode != null)
                {
                    stackNodes.Push(stackNodes.Peek().RightNode);
                    stackLeftHeight.Push(0);
                    stackRightHeight.Push(0);

                    continue;
                }
                else
                {
                    topInStack = stackNodes.Pop();
                    leftHeight = stackLeftHeight.Pop();
                    rightHeight = stackRightHeight.Pop();

                    if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().LeftNode)
                    {
                        if (leftHeight >= rightHeight)
                            stackLeftHeight.Push(stackLeftHeight.Pop() + leftHeight + 1);
                        else
                            stackLeftHeight.Push(stackLeftHeight.Pop() + rightHeight + 1);
                    }
                    else if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().RightNode)
                    {
                        if (leftHeight >= rightHeight)
                            stackRightHeight.Push(stackRightHeight.Pop() + leftHeight + 1);
                        else
                            stackRightHeight.Push(stackRightHeight.Pop() + rightHeight + 1);
                    }

                    while (stackNodes.Count != 0 && (stackNodes.Peek().RightNode == topInStack || stackNodes.Peek().RightNode == null))
                    {
                        topInStack = stackNodes.Pop();
                        leftHeight = stackLeftHeight.Pop();
                        rightHeight = stackRightHeight.Pop();

                        if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().LeftNode)
                        {
                            if (leftHeight >= rightHeight)
                                stackLeftHeight.Push(stackLeftHeight.Pop() + leftHeight + 1);
                            else
                                stackLeftHeight.Push(stackLeftHeight.Pop() + rightHeight + 1);
                        }
                        else if (stackNodes.Count != 0 && topInStack == stackNodes.Peek().RightNode)
                        {
                            if (leftHeight >= rightHeight)
                                stackRightHeight.Push(stackRightHeight.Pop() + leftHeight + 1);
                            else
                                stackRightHeight.Push(stackRightHeight.Pop() + rightHeight + 1);
                        }

                        if (Math.Abs(leftHeight - rightHeight) != 1)
                        {
                            Console.WriteLine("This is not an AVL.");

                            return;
                        }
                    }

                    if (stackNodes.Count != 0 && stackNodes.Peek().RightNode != null)
                    {
                        stackNodes.Push(stackNodes.Peek().RightNode);
                        stackLeftHeight.Push(0);
                        stackRightHeight.Push(0);
                    }
                }
            }

            Console.WriteLine("This is an AVL.");
        }

        public void CheckCompleteBTree()
        {
            bool foundEmpty = false;
            Node currentNode = null;
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                currentNode = queue.Dequeue();

                if (currentNode.LeftNode == null || currentNode.RightNode == null)
                    foundEmpty = true;

                if (foundEmpty &&
                    (currentNode.LeftNode != null || currentNode.RightNode != null))
                {
                    Console.WriteLine("This is not a complete binary tree.");

                    return;
                }

                if (currentNode.LeftNode != null)
                    queue.Enqueue(currentNode.LeftNode);
                if (currentNode.RightNode != null)
                    queue.Enqueue(currentNode.RightNode);
            }

            Console.WriteLine("This is a complete binary tree.");
        }
    }
}