using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DataStructure
{
    public class TrieTest
    {
        public static void EntryPoint()
        {
            //string[] inputs = new string[] { "test", "taste", "speed" },
            //         criterias = new string[] { "test", "test1", "speed", "speak" };

            string[] inputs = new string[] { "B", "BCM" },
                     criterias = new string[] { },
                     deletes = new string[] { "BCM" };

            Trie trie = new Trie();

            foreach (var item in inputs)
                trie.Insert(item);

            Console.WriteLine(trie.ToString());

            //foreach (var item in criterias)
            //    Console.WriteLine(trie.Search(item));

            foreach (var item in deletes)
                trie.Delete("BCM");

            Console.WriteLine(trie.ToString());
        }
    }

    class Trie
    {
        public TrieNode Root { get; set; }

        public Trie()
        {
            Root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode currentNode = this.Root;

            foreach (var item in word)
            {
                if (!currentNode.Dictionary.Keys.Contains(item))
                    currentNode.Dictionary.Add(item, new TrieNode());

                currentNode = currentNode.Dictionary[item];
            }

            currentNode.EndOfString = true;
        }

        public bool Search(string word)
        {
            TrieNode currentNode = this.Root;

            foreach (var item in word)
                if (!currentNode.Dictionary.Keys.Contains(item))
                    return false;
                else
                    currentNode = currentNode.Dictionary[item];

            return currentNode.EndOfString;
        }

        public void Delete(string word)
        {
            Delete(this.Root, word, 0);
        }

        private void Delete(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                current.EndOfString = false;

                return;
            }
            else if (current.Dictionary[word[index]] == null)
                return;

            Delete(current.Dictionary[word[index]], word, index + 1);

            if (current.Dictionary[word[index]].Dictionary.Count == 0 && !current.Dictionary[word[index]].EndOfString)
                current.Dictionary.Remove(word[index]);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Enumerate(this.Root, result, new StringBuilder());

            return result.ToString();
        }

        private void Enumerate(TrieNode node, StringBuilder result, StringBuilder previous)
        {
            if (node.EndOfString)
            {
                result.Append(previous.ToString());
                result.Append(" ");
            }

            if (node.Dictionary.Count != 0)
                foreach (var item in node.Dictionary.Keys)
                {
                    previous.Append(item);
                    Enumerate(node.Dictionary[item], result, previous);
                    previous.Remove(previous.Length - 1, 1);
                }
        }
    }

    class TrieNode
    {
        public Dictionary<char, TrieNode> Dictionary { get; set; }
        public bool EndOfString { get; set; }

        public TrieNode()
        {
            Dictionary = new Dictionary<char, TrieNode>();
            EndOfString = false;
        }
    }
}
