using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question17
    {
        public static void EntryPoint()
        {
            (new Question17()).LetterCombinations("2");
        }

        public IList<string> LetterCombinations(string digits)
        {
            if (digits == null || digits.Length == 0)
                return new List<string>();

            Hashtable hash = new Hashtable();
            char[][] graph = new char[digits.Length][];
            string temp = string.Empty;
            List<string> result = new List<string>();

            hash.Add('2', "abc");
            hash.Add('3', "def");
            hash.Add('4', "ghi");
            hash.Add('5', "jkl");
            hash.Add('6', "mno");
            hash.Add('7', "pqrs");
            hash.Add('8', "tuv");
            hash.Add('9', "wxyz");

            for (int i = 0; i < digits.Length; i++)
            {
                temp = (string)hash[digits[i]];

                graph[i] = new char[temp.Length];

                for (int j = 0; j < temp.Length; j++)
                    graph[i][j] = temp[j];
            }

            DFS(graph, 0, string.Empty, result);

            return result;
        }

        public void DFS(char[][] graph, int currentLayer, string previousCombination, List<string> result)
        {
            string currentCombination = string.Empty;

            if (graph.Length - 1 < currentLayer)
            {
                result.Add(previousCombination);
                return;
            }

            foreach (var item in graph[currentLayer])
            {
                currentCombination = previousCombination;

                DFS(graph, currentLayer + 1, currentCombination += item, result);
            }
        }
    }
}