using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question216
    {
        public static void EntryPoint()
        {
            (new Question216()).CombinationSum3(3, 7);
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Helper(result, new List<int>(), 1, k, n);

            return result;
        }

        private void Helper(IList<IList<int>> result, List<int> current, int start, int count, int target)
        {
            List<int> temp = null;

            if (count == 0)
            {
                if (target == 0)
                {
                    temp = new List<int>();

                    foreach (var item in current)
                        temp.Add(item);

                    result.Add(temp);
                }

                return;
            }

            for (int i = start; i <= 9; i++)
            {
                temp = new List<int>();

                foreach (var item in current)
                    temp.Add(item);

                temp.Add(i);

                Helper(result, temp, i + 1, count - 1, target - i);
            }
        }
    }
}
