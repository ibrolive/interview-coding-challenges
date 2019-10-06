using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question215
    {
        public static void EntryPoint()
        {
            (new Question215()).FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2);
        }

        public int FindKthLargest(int[] nums, int k)
        {
            MaxHeap heap = new MaxHeap(nums);
            int i = 0,
                result = 0;

            while (i++ < k)
                result = heap.Extract();

            return result;
        }
    }
}