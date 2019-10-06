using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question228
    {
        public static void EntryPoint()
        {
            (new Question228()).SummaryRanges(new int[] { 0, 2, 3, 4, 6, 8, 9 });
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            IList<string> result = new List<string>();
            int start = 0,
                end = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                start = nums[i];

                for (int j = i; j < nums.Length; j++)
                {
                    i = j;

                    if (j < nums.Length - 1 && nums[j + 1] - nums[j] != 1)
                    {
                        end = nums[j];

                        break;
                    }
                    else if (j == nums.Length - 1)
                        end = nums[j];
                }

                if (start != end)
                    result.Add(start.ToString() + "->" + end.ToString());
                else
                    result.Add(start.ToString());
            }

            return result;
        }
    }
}
