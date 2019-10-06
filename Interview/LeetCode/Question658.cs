using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question658
    {
        public static void EntryPoint()
        {
            (new Question658()).FindClosestElements(new int[] { 0, 0, 1, 2, 3, 3, 4, 7, 7, 8 }, 3, 5);
        }

        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            IList<int> result = new List<int>();
            int low = 0,
                high = arr.Length - 1,
                middle = 0;

            while (low <= high)
            {
                middle = low + (high - low) / 2;

                if (arr[middle] == x || (middle + 1 < arr.Length && arr[middle + 1] > x && arr[middle] < x))
                    break;
                else if (middle - 1 > -1 && arr[middle - 1] < x && arr[middle] > x)
                {
                    middle = middle - 1;
                    break;
                }
                else if (arr[middle] > x)
                    high = middle - 1;
                else
                    low = middle + 1;
            }

            if (high < 0)
            {
                low = 0;
                high = k - 1;
            }
            else if (low > arr.Length - 1)
            {
                low = arr.Length - k;
                high = arr.Length - 1;
            }
            else
            {
                low = high = middle;

                while (high - low < k - 1)
                    if (low > 0 && high < arr.Length - 1 && x - arr[low - 1] <= arr[high + 1] - x)
                        low--;
                    else if (low > 0 && high < arr.Length - 1 && x - arr[low - 1] > arr[high + 1] - x)
                        high++;
                    else if (low == 0)
                        high++;
                    else
                        low--;
            }

            for (int i = low; i <= high; i++)
                result.Add(arr[i]);

            return result;
        }
    }
}
