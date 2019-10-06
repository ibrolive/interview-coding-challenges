using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question133
    {
        Hashtable hash = new Hashtable();

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
                return node;

            return Clone(node);
        }

        private UndirectedGraphNode Clone(UndirectedGraphNode node)
        {
            UndirectedGraphNode destinationNode = null;

            if (hash.Contains(node.label))
                return (UndirectedGraphNode)hash[node.label];

            destinationNode = new UndirectedGraphNode(node.label);
            hash.Add(destinationNode.label, destinationNode);

            foreach (var item in node.neighbors)
                destinationNode.neighbors.Add(Clone(item));

            return destinationNode;
        }
    }

    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;

        public UndirectedGraphNode(int x)
        {
            label = x;
            neighbors = new List<UndirectedGraphNode>();
        }
    };
}