using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question729
    {

    }

    // https://leetcode.com/problems/my-calendar-i/solution/
    public class MyCalendar
    {
        public List<int[]> list = new List<int[]>();

        public MyCalendar()
        {

        }

        public bool Book(int start, int end)
        {
            foreach (var item in list)
                if (start < item[1] && end > item[0])
                    return false;

            list.Add(new int[] { start, end });

            return true;
        }
    }
}
