using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question77
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 1; i <= n; i++)
                Helper(i, n, k, new List<int>(), result);

            return result;
        }

        private void Helper(int index, int n, int k, List<int> previousRound, IList<IList<int>> result)
        {
            List<int> temp = null;

            previousRound.Add(index);

            if (previousRound.Count == k)
                result.Add(previousRound);
            else
            {
                for (int i = index + 1; i <= n; i++)
                {
                    temp = new List<int>();

                    foreach (var item in previousRound)
                        temp.Add(item);

                    Helper(i, n, k, temp, result);
                }
            }
        }
    }
}
