using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question406
    {
        public static void EntryPoint()
        {
            (new Question406()).ReconstructQueue(new int[,] { { 7, 0 }, { 4, 4 }, { 7, 1 }, { 5, 0 }, { 6, 1 }, { 5, 2 } });
        }

        public int[,] ReconstructQueue(int[,] people)
        {
            List<int[]> output = new List<int[]>();
            List<int>[] bucket = null;
            int boundary = 0;
            int[,] result = new int[people.GetLength(0), 2];

            for (int i = 0; i < people.GetLength(0); i++)
                if (people[i, 0] > boundary)
                    boundary = people[i, 0];

            bucket = new List<int>[boundary + 1];

            for (int i = 0; i < people.GetLength(0); i++)
            {
                if (bucket[people[i, 0]] == null)
                    bucket[people[i, 0]] = new List<int>();

                bucket[people[i, 0]].Add(people[i, 1]);
                bucket[people[i, 0]].Sort();
            }

            for (int i = bucket.Length - 1; i >= 0; i--)
                if (bucket[i] != null)
                {
                    foreach (var item in bucket[i])
                        if (item == 0)
                            output.Insert(0, new int[] { i, item });
                        else
                            output.Insert(item, new int[] { i, item });
                }

            for (int i = 0; i < output.Count; i++)
            {
                result[i, 0] = output[i][0];
                result[i, 1] = output[i][1];
            }

            return result;
        }
    }
}
