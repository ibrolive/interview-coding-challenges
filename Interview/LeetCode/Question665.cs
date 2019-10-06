using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question665
    {
        public bool CheckPossibility(int[] nums)
        {
            int[] A = new int[nums.Length], 
                  B = new int[nums.Length];

            bool a = true,
                 b = true;

            for (int i = 0; i < nums.Length; i++)
            {
                A[i] = nums[i];
                B[i] = nums[i];
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    A[i - 1] = A[i];
                    B[i] = B[i - 1];

                    break;
                }
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if (A[i - 1] > A[i])
                    a = false;

                if (B[i - 1] > B[i])
                    b = false;
            }

            return a || b;
        }
    }
}
