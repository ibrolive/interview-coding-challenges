using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question648
    {
        public string ReplaceWords(IList<string> dict, string sentence)
        {
            TrieNode root = new TrieNode();
            string[] words = sentence.Split(' ');
            StringBuilder builder = new StringBuilder();

            foreach (var item in dict)
            {
                TrieNode currentNode = root;

                foreach (var charactor in item)
                {
                    if (!currentNode.Set.Keys.Contains(charactor))
                        currentNode.Set.Add(charactor, new TrieNode());

                    currentNode = currentNode.Set[charactor];
                }

                currentNode.IsEnd = true;
            }

            foreach (var item in words)
            {
                TrieNode currentNode = root;
                StringBuilder temp = new StringBuilder();

                foreach (var charactor in item)
                {
                    if (currentNode.IsEnd)
                        break;

                    if (currentNode.Set.Keys.Contains(charactor))
                    {
                        currentNode = currentNode.Set[charactor];
                        temp.Append(charactor);
                    }
                    else
                    {
                        if (!currentNode.IsEnd)
                            temp = new StringBuilder(item);

                        break;
                    }
                }

                builder.Append(temp + " ");
            }

            return builder.ToString().Trim();
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Set = new Dictionary<char, TrieNode>();
            public bool IsEnd = false;
        }
    }
}
