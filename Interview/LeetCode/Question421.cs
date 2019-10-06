using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question421
    {
        // https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/discuss/91089/Java-Trie-+-short-explanation
        public int FindMaximumXOR(int[] nums)
        {
            int result = int.MinValue;
            TrieNode root = new TrieNode();

            foreach (var num in nums)
            {
                TrieNode current = root;

                for (int i = 31; i >= 0; i--)
                {
                    int bit = (num >> i) & 1;

                    if (current.children[bit] == null)
                        current.children[bit] = new TrieNode();

                    current = current.children[bit];
                }
            }

            foreach (var num in nums)
            {
                TrieNode current = root;
                int xorValue = 0;

                for (int i = 31; i >= 0; i--)
                {
                    int bit = (num >> i) & 1;

                    if (current.children[bit == 1 ? 0 : 1] != null)
                    {
                        xorValue += (1 << i);
                        current = current.children[bit == 1 ? 0 : 1];
                    }
                    else
                        current = current.children[bit];
                }

                result = Math.Max(xorValue, result);
            }

            return result;
        }

        public class TrieNode
        {
            public TrieNode[] children;

            public TrieNode()
            {
                children = new TrieNode[2];
            }
        }
    }
}
