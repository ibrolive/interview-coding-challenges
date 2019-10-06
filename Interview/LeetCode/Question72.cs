using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question72
    {
        public static void EntryPoint()
        {
            (new Question72()).MinDistance("horse", "ros");
        }

        // https://www.youtube.com/watch?v=We3YDTzNXEk&t=0s&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr&index=8
        // https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/EditDistance.java
        public int MinDistance(String word1, String word2)
        {
            int[,] temp = new int[word1.Length + 1, word2.Length + 1];

            for (int i = 0; i < temp.GetLength(0); i++)
                temp[i, 0] = i;

            for (int i = 0; i < temp.GetLength(1); i++)
                temp[0, i] = i;

            for (int i = 1; i <= word1.Length; i++)
                for (int j = 1; j <= word2.Length; j++)
                    if (word1[i - 1] == word2[j - 1])
                        temp[i, j] = temp[i - 1, j - 1];
                    else
                        temp[i, j] = 1 + min(temp[i - 1, j - 1], temp[i - 1, j], temp[i, j - 1]);

            printActualEdits(temp, word1.ToCharArray(), word2.ToCharArray());

            return temp[word1.Length, word2.Length];
        }

        private int min(int a, int b, int c)
        {
            int l = Math.Min(a, b);
            return Math.Min(l, c);
        }

        public void printActualEdits(int[,] T, char[] str1, char[] str2)
        {
            int i = T.GetLength(0) - 1;
            int j = T.GetLength(1) - 1;
            while (true)
            {
                if (i == 0 || j == 0)
                {
                    break;
                }
                if (str1[i - 1] == str2[j - 1])
                {
                    i = i - 1;
                    j = j - 1;
                }
                else if (T[i, j] == T[i - 1, j - 1] + 1)
                {
                    Console.WriteLine("Edit " + str2[j - 1] + " in string2 to " + str1[i - 1] + " in string1");
                    i = i - 1;
                    j = j - 1;
                }
                else if (T[i, j] == T[i - 1, j] + 1)
                {
                    Console.WriteLine("Delete in string1 " + str1[i - 1]);
                    i = i - 1;
                }
                else if (T[i, j] == T[i, j - 1] + 1)
                {
                    Console.WriteLine("Delete in string2 " + str2[j - 1]);
                    j = j - 1;
                }
                else
                {
                    throw new Exception("Some wrong with given data");
                }

            }
        }
    }
}
