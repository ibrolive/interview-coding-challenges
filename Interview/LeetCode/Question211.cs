using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question211
    {
        public static void EntryPoint()
        {
            WordDictionary dictionary = new WordDictionary();
            dictionary.AddWord(string.Empty);
            dictionary.AddWord("a");
            dictionary.AddWord("ab");
            dictionary.Search("a");

        }

        class WordDictionary
        {
            class TrieNode
            {
                public Hashtable Dictionary { get; set; }

                public bool End { get; set; }

                public TrieNode()
                {
                    Dictionary = new Hashtable();
                }
            }

            private TrieNode root = null;

            public WordDictionary()
            {
                this.root = new TrieNode();
            }

            public void AddWord(string word)
            {
                if (word == string.Empty)
                    return;

                TrieNode currentNode = root;

                foreach (var item in word)
                {
                    if (!currentNode.Dictionary.Contains(item))
                        currentNode.Dictionary.Add(item, new TrieNode());

                    currentNode = (TrieNode)currentNode.Dictionary[item];
                }

                currentNode.End = true;
            }

            public bool Search(string word)
            {
                return WildcardSearch(root, word);
            }

            private bool WildcardSearch(TrieNode currentRoot, string subWord)
            {
                TrieNode currentNode = currentRoot;

                for (int i = 0; i < subWord.Length; i++)
                    if (subWord[i] == '.')
                    {
                        foreach (var item in currentNode.Dictionary.Keys)
                        {
                            if (WildcardSearch((TrieNode)currentNode.Dictionary[item], subWord.Substring(i + 1, subWord.Length - i - 1)))
                                return true;
                        }

                        return false;
                    }
                    else if (currentNode.Dictionary.Contains(subWord[i]))
                        currentNode = (TrieNode)currentNode.Dictionary[subWord[i]];
                    else
                        return false;

                if (currentNode.End)
                    return true;

                return false;
            }
        }
    }
}
