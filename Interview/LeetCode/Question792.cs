using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question792
    {
        public int NumMatchingSubseq(string S, string[] words)
        {
            int ans = 0;
            List<Node>[] heads = new List<Node>[26];

            for (int i = 0; i < 26; i++)
                heads[i] = new List<Node>();

            foreach (var word in words)
                heads[word[0] - 'a'].Add(new Node(word, 0));

            foreach (var c in S.ToCharArray())
            {
                List<Node> old_bucket = heads[c - 'a'];
                heads[c - 'a'] = new List<Node>();

                foreach (var node in old_bucket)
                {
                    node.index++;

                    if (node.index == node.word.Length)
                        ans++;
                    else
                        heads[node.word[node.index] - 'a'].Add(node);
                }
            }

            return ans;
        }

        public class Node
        {
            public string word;
            public int index;

            public Node(string w, int i)
            {
                this.word = w;
                this.index = i;
            }
        }
    }
}
