using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question120
    {
        public static void EntryPoint()
        {
            List<List<int>> triangle = new List<List<int>>();

            List<int> level1 = new List<int>();
            level1.Add(2);
            List<int> level2 = new List<int>();
            level2.Add(3);
            level2.Add(4);
            List<int> level3 = new List<int>();
            level3.Add(6);
            level3.Add(5);
            level3.Add(7);
            List<int> level4 = new List<int>();
            level4.Add(4);
            level4.Add(1);
            level4.Add(8);
            level4.Add(3);

            triangle.Add(level1);
            triangle.Add(level2);
            triangle.Add(level3);
            triangle.Add(level4);

            (new Question120()).MinimumTotal(triangle);
        }

        public int MinimumTotal(List<List<int>> triangle)
        {
            if (triangle == null)
                return 0;
            else if (triangle[0] == null)
                return 0;
            else if (triangle.Count == 1)
                return triangle[0][0];

            List<List<int>> temp = new List<List<int>>();
            int min = int.MaxValue;

            temp.Add(new List<int>());
            temp[0].Add(triangle[0][0]);

            for (int i = 1; i <= triangle.Count - 1; i++)
            {
                temp.Add(new List<int>());

                temp[i].Add(temp[i - 1][0] + triangle[i][0]);

                if (triangle.Count > 2)
                    for (int j = 1; j <= triangle[i].Count - 2; j++)
                        temp[i].Add(Math.Min(temp[i - 1][j - 1] + triangle[i][j],
                                             temp[i - 1][j] + triangle[i][j]));

                temp[i].Add(temp[i - 1][temp[i - 1].Count - 1] + triangle[i][triangle[i].Count - 1]);
            }

            foreach (var item in temp[temp.Count - 1])
                min = Math.Min(min, item);

            return min;
        }
    }
}