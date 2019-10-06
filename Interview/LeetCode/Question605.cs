using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question605
    {
        public static void EntryPoint()
        {
            //(new Question605()).CanPlaceFlowers(new int[] { 1, 0, 0, 0, 0, 0, 1 }, 2);
            (new Question605()).CanPlaceFlowers(new int[] { 1, 0, 0, 0, 0, 1 }, 2);
            //(new Question605()).CanPlaceFlowers(new int[] { 0, 0 }, 1);
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if ((i - 1 < 0 || flowerbed[i - 1] == 0) &&
                    flowerbed[i] == 0 &&
                    (i + 1 > flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    n--;
                }
            }

            return n <= 0;
        }
    }
}
