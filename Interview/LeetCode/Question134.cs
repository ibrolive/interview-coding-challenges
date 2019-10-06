using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question134
    {
        public static void EntryPoint()
        {
            (new Question134()).CanCompleteCircuit(new int[] { 3, 1, 1 }, new int[] { 1, 2, 2 });
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int visited = 0,
                currentIndex = 0,
                remainInTank = 0;

            for (int i = 0; i <= gas.Length - 1; i++)
            {
                if (gas[i] >= cost[i])
                {
                    visited = 0;
                    currentIndex = i;
                    remainInTank = 0;

                    while (visited < gas.Length)
                    {
                        visited++;
                        remainInTank = remainInTank + gas[currentIndex] - cost[currentIndex];

                        if (remainInTank >= 0)
                        {
                            if (currentIndex == gas.Length - 1 && visited < gas.Length)
                                currentIndex = 0;
                            else
                                currentIndex++;
                        }
                        else
                            break;
                    }

                    if (visited == gas.Length && remainInTank >= 0)
                        return i;
                }
            }

            return -1;
        }
    }
}
