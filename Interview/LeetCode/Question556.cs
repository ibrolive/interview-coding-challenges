using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question556
    {
        public int NextGreaterElement(int n)
        {
            char[] a = ("" + n).ToCharArray();
            int i = a.Length - 2;

            while (i >= 0 && a[i + 1] <= a[i])
                i--;

            if (i < 0)
                return -1;

            int j = a.Length - 1;

            while (j >= 0 && a[j] <= a[i])
                j--;

            Swap(a, i, j);
            Reverse(a, i + 1);

            try
            {
                return Convert.ToInt32(new String(a));
            }
            catch
            {
                return -1;
            }
        }

        private void Reverse(char[] a, int start)
        {
            int i = start, j = a.Length - 1;

            while (i < j)
            {
                Swap(a, i, j);
                i++;
                j--;
            }
        }

        private void Swap(char[] a, int i, int j)
        {
            char temp = a[i];

            a[i] = a[j];
            a[j] = temp;
        }
    }
}
