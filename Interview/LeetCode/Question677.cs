using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question677
    {
        public static void EntryPoint()
        {
            MapSum obj = new MapSum();

            obj.Insert("apple", 3);
            obj.Sum("ap");
            obj.Insert("app", 2);
            obj.Sum("ap");
        }
    }

    public class MapSum
    {
        private TrieNode _root = null;
        private int _sum = 0;

        public MapSum()
        {
            _root = new TrieNode();
        }

        public void Insert(string key, int val)
        {
            TrieNode currentNode = _root;

            foreach (var item in key)
            {
                if (!currentNode.Set.Keys.Contains(item))
                    currentNode.Set.Add(item, new TrieNode());

                currentNode = currentNode.Set[item];
            }

            currentNode.IsEnd = true;
            currentNode.Val = val;
        }

        public int Sum(string prefix)
        {
            int result = 0;
            TrieNode currentNode = _root;

            foreach (var item in prefix)
            {
                if (!currentNode.Set.Keys.Contains(item))
                    return 0;

                currentNode = currentNode.Set[item];
            }

            Helper(currentNode);
            result = this._sum;
            this._sum = 0;

            return result;
        }

        private void Helper(TrieNode node)
        {
            if (node.IsEnd)
                this._sum += node.Val;

            foreach (var item in node.Set.Values)
                Helper(item);
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Set = new Dictionary<char, TrieNode>();
            public bool IsEnd = false;
            public int Val = 0;
        }
    }
}
