using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question349
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == nums2 ||
                nums1 == null || nums1.Length == 0 ||
                nums2 == null || nums2.Length == 0)
                return new int[] { };

            List<int> result = new List<int>();
            int index1 = 0,
                index2 = 0;

            Array.Sort(nums1);
            Array.Sort(nums2);

            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                while (index1 + 1 < nums1.Length && nums1[index1] == nums1[index1 + 1])
                    index1++;

                while (index2 + 1 < nums2.Length && nums2[index2] == nums2[index2 + 1])
                    index2++;

                if (nums1[index1] == nums2[index2])
                {
                    result.Add(nums1[index1]);

                    index1++;
                    index2++;
                }
                else if (nums1[index1] < nums2[index2])
                    index1++;
                else
                    index2++;
            }

            return result.ToArray<int>();
        }
    }
}
