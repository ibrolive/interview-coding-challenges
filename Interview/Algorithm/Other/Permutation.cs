using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Algorithm.Other
{
    class Permutation
    {
        public static void EntryPoint()
        {
            string source = "ABCD";
            List<string> result = new List<string>();

            (new Permutation()).GetPermutation(source, new StringBuilder(), new bool[source.Length], result);

            foreach (var item in result)
                Console.WriteLine(item);
        }

        public void GetPermutation(string source, StringBuilder current, bool[] visited, List<string> result)
        {
            if (source.Length == current.Length)
                result.Add(current.ToString());
            else
                for (int i = 0; i < source.Length; i++)
                    if (!visited[i])
                    {
                        visited[i] = true;
                        current.Append(source[i]);

                        GetPermutation(source, current, visited, result);

                        visited[i] = false;
                        current.Remove(current.Length - 1, 1);
                    }
        }
    }
}
