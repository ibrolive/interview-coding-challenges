using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question88
    {
        public static void EntryPoint()
        {
            int[] nums1 = new int[5];
            int[] nums2 = new int[2];

            nums1[0] = 0;
            nums1[1] = 2;
            nums1[2] = 4;

            nums2[0] = 6;
            nums2[1] = 8;

            (new Question88()).Merge(nums1, 3, nums2, 2);
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1 == null)
                return;
            if (nums2 == null)
                return;

            int i = m - 1, j = n - 1, k = m + n - 1;

            while (i > -1 && j > -1)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }

                k--;
            }

            while (j > -1)
            {
                nums1[k] = nums2[j];
                j--;
                k--;
            }
        }
    }
}