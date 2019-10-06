using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question904
    {
        public static void EntryPoint()
        {
            (new Question904()).TotalFruit(new int[] { 0, 1, 2, 2 });
        }

        public int TotalFruit(int[] tree)
        {
            int max = 0,
                currentCount = 0,
                i = 0,
                j = 0,
                fruitType1 = -1,
                fruitType2 = -1;

            while (j < tree.Length)
            {
                if (fruitType1 == tree[j] || fruitType2 == tree[j])
                {
                    currentCount++;
                    j++;
                }
                else if (fruitType1 == -1)
                {
                    fruitType1 = tree[j];
                    currentCount++;
                    j++;
                }
                else if (fruitType2 == -1)
                {
                    fruitType2 = tree[j];
                    currentCount++;
                    j++;
                }
                else
                {
                    max = max >= currentCount ? max : currentCount;
                    fruitType1 = -1;
                    fruitType2 = -1;
                    currentCount = 0;

                    if (i + 1 < tree.Length && tree[i] == tree[i + 1])
                        i++;

                    j = ++i;
                }
            }

            return max >= currentCount ? max : currentCount;
        }
    }
}
