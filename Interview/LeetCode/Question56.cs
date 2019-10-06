using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode.Question56
{
    class Question56
    {
        public static void EntryPoint()
        {
            List<Interval> input = new List<Interval>();
            Interval interval1 = new Interval(1, 10);
            Interval interval2 = new Interval(2, 3);
            Interval interval3 = new Interval(2, 1);
            //Interval interval3 = new Interval(4, 8);
            Interval interval4 = new Interval(6, 7);
            Interval interval5 = new Interval(8, 9);
            input.Add(interval1);
            input.Add(interval2);
            input.Add(interval3);
            input.Add(interval4);
            input.Add(interval5);

            (new Interview.LeetCode.Question56.Question56()).Merge(input);
        }

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> result = new List<Interval>();
            int start = 0,
                end = 0;

            intervals = intervals.OrderBy(x => x.start).ThenBy(x => x.end).ToList<Interval>();
            intervals.Add(new Interval(int.MaxValue, int.MaxValue));

            start = intervals[0].start;
            end = intervals[0].end;
            for (int i = 1; i <= intervals.Count - 1; i++)
            {
                if (intervals[i].start <= end)
                    end = Math.Max(end, intervals[i].end);
                else
                {
                    result.Add(new Interval(start, end));
                    start = intervals[i].start;
                    end = intervals[i].end;
                }
            }

            return result;
        }
    }

    public class Interval
    {
        public int start;
        public int end;

        public Interval()
        {
            start = 0;
            end = 0;
        }

        public Interval(int s, int e)
        {
            start = s;
            end = e;
        }
    }
}