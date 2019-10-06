using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question676
    {
        public static void EntryPoint()
        {
            MagicDictionary obj = new MagicDictionary();

            obj.BuildDict(new string[] { "hello", "leetcode" });
            obj.Search("hhllo");
            obj.Search("hello");
            obj.Search("hell");
        }
    }

    public class MagicDictionary
    {
        TrieNode root = null;

        public MagicDictionary()
        {
            root = new TrieNode();
        }

        public void BuildDict(string[] dict)
        {
            TrieNode currentNode = null;

            foreach (var item in dict)
            {
                currentNode = root;

                foreach (var charactor in item)
                {
                    if (!currentNode.Set.Keys.Contains(charactor))
                        currentNode.Set.Add(charactor, new TrieNode());

                    currentNode = currentNode.Set[charactor];
                }

                currentNode.IsEnd = true;
            }
        }

        public bool Search(string word)
        {
            StringBuilder builder = new StringBuilder(word);
            char temp = '\0';
            TrieNode currentNode = root;

            for (int i = 0; i < builder.Length; i++)
                for (int j = 0; j < 26; j++)
                {
                    if ((char)(j + 'a') == builder[i])
                        continue;

                    temp = builder[i];
                    builder[i] = (char)(j + 'a');

                    if (SearchInTrie(builder.ToString()))
                        return true;

                    builder[i] = temp;
                }

            return false;
        }

        private bool SearchInTrie(string word)
        {
            TrieNode currentNode = root;

            foreach (var charactor in word)
                if (currentNode.Set.Keys.Contains(charactor))
                    currentNode = currentNode.Set[charactor];
                else
                    return false;

            return currentNode.IsEnd;
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Set = new Dictionary<char, TrieNode>();
            public bool IsEnd = false;
        }
    }
}
