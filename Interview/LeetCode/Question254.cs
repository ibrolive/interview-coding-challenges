using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question254
    {
        public static void EntryPoint()
        {
            (new Question254()).GetFactors(32);
        }

        public IList<IList<int>> GetFactors(int n)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Helper(result, new List<int>(), n, 2);

            return result;
        }

        private void Helper(IList<IList<int>> result, List<int> previous, int n, int start)
        {
            List<int> temp = null;

            if (n == 1 && previous.Count > 1)
            {
                result.Add(previous);

                return;
            }

            for (int i = start; i <= n; i++)
                if (n % i == 0)
                {
                    temp = new List<int>();

                    foreach (var item in previous)
                        temp.Add(item);

                    temp.Add(i);
                    Helper(result, temp, n / i, i);
                }
        }
    }
}
