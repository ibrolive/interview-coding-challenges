using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question433
    {
        // https://leetcode.com/problems/minimum-genetic-mutation/discuss/335366/C-BFS-brute-force
        public int MinMutation(string start, string end, string[] bank)
        {
            if (start == end)
                return 0;

            HashSet<string> bankSet = new HashSet<string>(bank),
                            isVisited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            char[] choices = new char[] { 'A', 'C', 'G', 'T' };
            int steps = 1;

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int s = 0; s < size; s++)
                {
                    string cur = queue.Dequeue();
                    char[] curArray = cur.ToArray();

                    for (int i = 0; i < curArray.Length; i++)
                        foreach (var c in choices)
                        {
                            curArray[i] = c;

                            string tempCur = new string(curArray);

                            if (isVisited.Contains(tempCur))
                                continue;

                            if (bankSet.Contains(tempCur))
                            {
                                if (tempCur == end)
                                    return steps;

                                isVisited.Add(tempCur);
                                queue.Enqueue(tempCur);
                            }

                            curArray[i] = cur[i];
                        }
                }

                steps++;
            }

            return -1;
        }
    }
}
