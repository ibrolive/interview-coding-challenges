using System;

namespace Interview.Algorithm.DynamicProgramming
{
    // *L*ongest *I*ncreasing *S*ubsequence
    class LIS
    {
        public static void EntryPoint()
        {
            //int[] input = new int[] { 5, 3, 4, 5, 6, 7 };
            int[] input = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };

            (new LIS()).GetLISLength(input);
        }

        // O (n^2)
        private int GetLISLength(int[] input)
        {
            if (input == null || input.Length == 0)
                return 0;
            else if (input.Length == 1)
                return 1;

            int currentLength = 1;
            int[] continousLength = new int[input.Length];

            for (int i = 0; i <= input.Length - 1; i++)
            {
                continousLength[i] = 1;

                for (int j = 0; j < i; j++)
                    if (input[j] < input[i])
                        continousLength[i] = Math.Max(continousLength[j] + 1, continousLength[i]);

                currentLength = Math.Max(continousLength[i], currentLength);
            }

            return currentLength;
        }

        // O (nlgn)
        private void LIS2()
        {
            int LISLength = 0;
            int LISIndex = 0;
            int[] orginalList = new int[] { 2, 1, 5, 3, 6, 4, 8, 9, 7 };
            int[] LIS = new int[9];

            LIS[0] = orginalList[0];
            LISLength++;
            for (int i = 1; i < orginalList.Length; i++)
            {
                LISIndex = GetLISIndex(LIS, LISLength, orginalList[i]);
                if (LISIndex == -1)
                {
                    LIS[LISLength] = orginalList[i];
                    LISLength++;
                }
                else if (LISIndex + 1 >= LISLength)
                {
                    LIS[LISIndex] = orginalList[i];
                    LISLength = LISIndex + 1;
                }
            }

            for (int i = 0; i < LISLength; i++)
            {
                Console.WriteLine(LIS[i]);
            }
        }

        // 折半插入排序
        private static int GetLISIndex(int[] LIS, int LISLength, int currentValue)
        {
            int lowPosition = 0;
            int highPosition = LISLength - 1;
            int lastPosition = 0;

            while (lowPosition <= highPosition)
            {
                if (LIS[(lowPosition + highPosition) / 2] > currentValue)
                {
                    highPosition = (lowPosition + highPosition) / 2 - 1;
                    lastPosition = lowPosition;
                }
                else if (LIS[(lowPosition + highPosition) / 2] < currentValue)
                {
                    lowPosition = (lowPosition + highPosition) / 2 + 1;
                    lastPosition = highPosition;
                }
                else if (LIS[(lowPosition + highPosition) / 2] == currentValue)
                    return (lowPosition + highPosition) / 2;
            }

            if (LIS[lastPosition] > currentValue)
                return lastPosition;
            else
                return -1;
        }
    }
}