using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question255
    {
        public static void EntryPoint()
        {
            (new Question255()).VerifyPreorder(new int[] { 5, 2, 1, 3, 6 });
        }

        public bool VerifyPreorder(int[] preorder)
        {
            return Helper(preorder, 0, preorder.Length - 1);
        }

        private bool Helper(int[] array, int start, int end)
        {
            if (start >= end || start >= array.Length)
                return true;

            int leftSubTree = Int32.MinValue;

            for (int i = start; i <= end; i++)
            {
                if (array[start] < array[i] && leftSubTree < 0)
                    leftSubTree = i;

                if (array[start] > array[i] && leftSubTree > 0)
                    return false;
            }

            leftSubTree = leftSubTree < 0 ? start + 1 : leftSubTree;

            return Helper(array, start, leftSubTree - 1) && Helper(array, leftSubTree, end);
        }
    }
}
