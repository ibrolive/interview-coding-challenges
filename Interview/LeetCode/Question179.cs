using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question179
    {
        public static void EntryPoint()
        {
            (new Question179()).LargestNumber(new int[] { 1, 2 });
        }

        public string LargestNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return string.Empty;

            Array.Sort(nums, new Comparer());
            StringBuilder builder = new StringBuilder();

            foreach (var item in nums)
                builder.Append(item.ToString());

            while (builder[0] == '0' && builder.Length > 1)
                builder.Remove(0, 1);

            return builder.ToString();
        }

        public class Comparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return -(x.ToString() + y.ToString()).CompareTo(y.ToString() + x.ToString());
            }
        }
    }
}
