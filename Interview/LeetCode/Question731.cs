using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question731
    {
    }

    public class MyCalendarTwo
    {
        private List<int[]> calendar = new List<int[]>(),
                            overlap = new List<int[]>();

        public MyCalendarTwo()
        {

        }

        public bool Book(int start, int end)
        {
            foreach (var item in overlap)
                if (start < item[1] && item[0] < end)
                    return false;

            foreach (var item in calendar)
                if (start < item[1] && item[0] < end)
                    overlap.Add(new int[] { Math.Max(item[0], start), Math.Min(item[1], end) });

            calendar.Add(new int[] { start, end });

            return true;
        }
    }
}
