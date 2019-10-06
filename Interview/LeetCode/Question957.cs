using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question957
    {
        public static void EntryPoint()
        {
            (new Question957()).PrisonAfterNDays(new int[] { 0, 1, 0, 1, 1, 0, 0, 1 }, 7);
        }

        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            bool hasCycle = false;
            int cycle = 0;
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < N; i++)
            {
                int[] next = nextDay(cells);
                string key = String.Join("", next.Select(p => p.ToString()).ToArray());

                if (!set.Contains(key))
                {
                    set.Add(key);
                    cycle++;
                }
                else
                {
                    hasCycle = true;
                    break;
                }

                cells = next;
            }

            if (hasCycle)
            {
                N %= cycle;
                for (int i = 0; i < N; i++)
                {
                    cells = nextDay(cells);
                }
            }

            return cells;
        }

        private int[] nextDay(int[] cells)
        {
            int[] tmp = new int[cells.Length];
            tmp[0] = tmp[tmp.Length - 1] = 0;

            for (int j = 1; j < cells.Length - 1; j++)
                tmp[j] = (cells[j - 1] == cells[j + 1]) ? 1 : 0;

            return tmp;
        }
    }
}
