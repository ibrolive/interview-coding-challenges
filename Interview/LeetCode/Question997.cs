using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question997
    {
        public static void EntryPoint()
        {
            int N = 2;
            int[][] trust = new int[1][];

            trust[0] = new int[] { 1, 2 };

            (new Question997()).FindJudge(N, trust);
        }

        public int FindJudge(int N, int[][] trust)
        {
            int result = -1;
            List<int>[] people = new List<int>[N];

            foreach (var item in trust)
            {
                if (people[item[1] - 1] == null)
                    people[item[1] - 1] = new List<int>();

                people[item[1] - 1].Add(item[0]);
            }

            for (int i = 0; i < N; i++)
                if (people[i] != null && people[i].Count == N - 1)
                {
                    if (result != -1)
                        return -1;
                    else
                        result = i + 1;
                }

            foreach (var item in people)
                if (item != null && item.Contains(result))
                    return -1;

            return result;
        }
    }
}
