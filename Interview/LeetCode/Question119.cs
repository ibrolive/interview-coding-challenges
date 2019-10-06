using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question119
    {
        public static void EntryPoint()
        {
            List<int> result =(List<int>)(new Question119()).GetRow(2);
        }

        public IList<int> GetRow(int rowIndex)
        {
            List<int>[] results = new List<int>[rowIndex + 1];

            results[0] = new List<int>();
            results[0].Add(1);

            if (rowIndex != 0)
            {
                for (int row = 1; row <= rowIndex; row++)
                {
                    results[row] = new List<int>();

                    results[row].Add(1);

                    if (row > 1)
                        for (int i = 1; i <= row - 1; i++)
                            results[row].Add(results[row - 1][i - 1] + results[row - 1][i]);

                    results[row].Add(1);
                }
            }

            return results[rowIndex];
        }
    }
}