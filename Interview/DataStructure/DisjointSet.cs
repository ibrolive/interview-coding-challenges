using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DataStructure
{
    class UnionFindTest
    {
        public static void EntryPoint()
        {
            DisjointSet.Node node1 = new DisjointSet.Node(1);
            DisjointSet.Node node2 = new DisjointSet.Node(2);
            DisjointSet.Node node3 = new DisjointSet.Node(3);

            DisjointSet.Node[] nodes = { node1, node2, node3 };

            DisjointSet set = new DisjointSet(nodes);
            set.Union(node1, node2);
            set.Union(node2, node3);

            Console.WriteLine(set.Find(node2).Value);
        }
    }

    // https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/DisjointSet.java
    class DisjointSet
    {
        Dictionary<int, Node> set = new Dictionary<int, Node>();

        public DisjointSet(Node[] nodes)
        {
            foreach (var node in nodes)
                set.Add(node.Value, node);
        }

        public Node Find(Node node)
        {
            if (!set.ContainsKey(node.Value))
                return null;

            if (set[node.Value].Parent.Value != node.Value)
                set[node.Value].Parent = Find(set[node.Value].Parent);

            return set[node.Value].Parent;
        }

        public void Union(Node node1, Node node2)
        {
            Node parentNode1 = Find(node1).Parent,
                 parentNode2 = Find(node2).Parent;

            if (parentNode1 == parentNode2)
                return;
            else if (parentNode1.Rank >= parentNode2.Rank)
            {
                parentNode1.Rank = parentNode1.Rank == parentNode2.Rank ? parentNode1.Rank + 1 : parentNode1.Rank;
                parentNode2.Parent = parentNode1;
            }
            else
                parentNode1.Parent = parentNode2;
        }

        public class Node
        {
            public int Value { get; set; }

            public Node Parent { get; set; }

            public int Rank { get; set; }

            public Node(int value)
            {
                this.Value = value;
                this.Parent = this;
                this.Rank = 0;
            }
        }
    }
}
