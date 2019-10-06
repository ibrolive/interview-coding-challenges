using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question720
    {
        public static void EntryPoint()
        {
            //(new Question720()).LongestWord(new string[] { "rac", "rs", "ra", "on", "r", "otif", "o", "onpdu", "rsf", "rs", "ot", "oti", "racy", "onpd" });
            (new Question720()).LongestWord(new string[] { "w", "wo", "wor", "worl", "world" });
            //(new Question720()).LongestWord(new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" });
            //(new Question720()).LongestWord(new string[] { "m", "mo", "moc", "moch", "mocha", "l", "la", "lat", "latt", "latte", "c", "ca", "cat" });
            //(new Question720()).LongestWord(new string[] { "ogz", "eyj", "e", "ey", "hmn", "v", "hm", "ogznkb", "ogzn", "hmnm", "eyjuo", "vuq", "ogznk", "og", "eyjuoi", "d" });
        }

        public StringBuilder result = new StringBuilder();

        public string LongestWord(string[] words)
        {
            Trie trie = new Trie();

            foreach (var item in words)
                trie.InsertWord(item);

            Helper(trie.root, new StringBuilder());

            return result.ToString();
        }

        public void Helper(Node currentNode, StringBuilder previous)
        {
            if (currentNode.dictionary.Count != 0)
                foreach (var item in currentNode.dictionary.Keys)
                {
                    if (currentNode.dictionary[item].endOfString)
                    {
                        previous.Append(item);
                        Helper(currentNode.dictionary[item], previous);
                        previous.Remove(previous.Length - 1, 1);
                    }
                    else if (previous.Length > result.Length)
                        result = new StringBuilder(previous.ToString());
                }
            else if (previous.Length > result.Length)
                result = new StringBuilder(previous.ToString());
        }

        public class Node
        {
            public bool endOfString = false;
            public SortedDictionary<char, Node> dictionary = new SortedDictionary<char, Node>();
        }

        public class Trie
        {
            public Node root = new Node();

            public void InsertWord(string word)
            {
                Node currentNode = root;

                foreach (var item in word)
                {
                    if (!currentNode.dictionary.Keys.Contains(item))
                        currentNode.dictionary.Add(item, new Node());

                    currentNode = currentNode.dictionary[item];
                }

                currentNode.endOfString = true;
            }
        }
    }
}
