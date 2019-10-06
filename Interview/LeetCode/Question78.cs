using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question78
    {
        public static void EntryPoint()
        {
            (new Question78()).Subsets(new int[] { 1, 2, 3 });
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            List<IList<int>> result = new List<IList<int>>();
            List<IList<int>> tempResult = null;
            List<int> tempList = null;

            result.Add(new List<int>());

            foreach (int n in nums)
            {
                tempResult = new List<IList<int>>();
                foreach (IList<int> list in result)
                {
                    tempList = new List<int>(list);
                    tempList.Add(n);

                    tempResult.Add(tempList);
                }

                result.AddRange(tempResult);
            }

            return result;
        }
    }
}