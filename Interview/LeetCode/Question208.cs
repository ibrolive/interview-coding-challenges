using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question208
    {
        public static void EntryPoint()
        {
            Trie tree = new Trie();
            bool result = false;

            tree.Insert("apple");
            result = tree.Search("apple");
        }
    }

    public class Trie
    {
        private TrieNode root = new TrieNode();

        /** Initialize your data structure here. */
        public Trie()
        {
            root.IsEnd = true;
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode currentNode = root,
                     nextNode = null;

            foreach (var item in word)
                if (!currentNode.Map.ContainsKey(item))
                {
                    nextNode = new TrieNode();
                    currentNode.Map.Add(item, nextNode);
                    currentNode = nextNode;
                }
                else
                    currentNode = currentNode.Map[item];

            currentNode.IsEnd = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode currentNode = root;

            foreach (var item in word)
                if (currentNode.Map.ContainsKey(item))
                    currentNode = currentNode.Map[item];
                else
                    return false;

            if (currentNode.IsEnd)
                return true;

            return false;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            TrieNode currentNode = root;

            foreach (var item in prefix)
                if (currentNode.Map.ContainsKey(item))
                    currentNode = currentNode.Map[item];
                else
                    return false;

            return true;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Map { get; set; }
        public bool IsEnd { get; set; }

        public TrieNode()
        {
            Map = new Dictionary<char, TrieNode>();
        }
    }
}
