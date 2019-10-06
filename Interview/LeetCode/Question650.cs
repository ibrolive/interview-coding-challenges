using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question650
    {
        public static void EntryPoint()
        {
            (new Question650()).MinSteps(11);
        }

        public int MinSteps(int n)
        {
            if (n == 1)
                return 0;

            int[] steps = new int[n + 1];
            List<int>[] clipboard = new List<int>[n + 1];

            for (int i = 2; i <= n; i++)
            {
                steps[i] = Int32.MaxValue;
                clipboard[i] = new List<int>();
            }

            steps[2] = 2;

            clipboard[2].Add(1);

            for (int i = 3; i <= n; i++)
            {
                for (int j = i % 2 == 0 ? i / 2 : i / 2 + 1; j < i; j++)
                {
                    int gap = i - j,
                        minStep = Int32.MaxValue,
                        curClipboard = 0;

                    foreach (var item in clipboard[j])
                        if (gap % item == 0 && minStep > gap / item)
                        {
                            minStep = steps[j] + gap / item;
                            curClipboard = item;
                        }

                    if (steps[i] > minStep)
                    {
                        steps[i] = minStep;

                        clipboard[i].Clear();
                        clipboard[i].Add(curClipboard);
                    }
                    else if (steps[i] == minStep)
                        clipboard[i].Add(curClipboard);
                }

                if (i % 2 == 0 && steps[i / 2] + 2 <= steps[i])
                {
                    steps[i] = steps[i / 2] + 2;

                    clipboard[i].Clear();
                    clipboard[i].Add(i / 2);
                }
            }

            return steps[n];
        }
    }
}
