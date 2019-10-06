using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question118
    {
        public IList<IList<int>> Generate(int numRows)
        {
            List<int>[] results = new List<int>[numRows];

            if (numRows != 0)
            {

                results[0] = new List<int>();
                results[0].Add(1);

                if (numRows != 0)
                {
                    for (int row = 1; row <= numRows - 1; row++)
                    {
                        results[row] = new List<int>();

                        results[row].Add(1);

                        if (row > 1)
                            for (int i = 1; i <= row - 1; i++)
                                results[row].Add(results[row - 1][i - 1] + results[row - 1][i]);

                        results[row].Add(1);
                    }
                }
            }

            return results;
        }
    }
}