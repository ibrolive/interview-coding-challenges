using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question253
    {
        // https://leetcode.com/problems/meeting-rooms-ii/discuss/175314/EASY-AF-JAVA-solution-beats-100
        public int MinMeetingRooms(Interval[] intervals)
        {
            int result = 0;
            int[] startTime = new int[intervals.Length],
                  endTime = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                startTime[i] = intervals[i].start;
                endTime[i] = intervals[i].end;
            }

            Array.Sort(startTime);
            Array.Sort(endTime);

            for (int indexStartTime = 0, indexEndTime = 0; indexStartTime < startTime.Length; indexStartTime++)
                if (startTime[indexStartTime] < endTime[indexEndTime])
                    result++;
                else
                    indexEndTime++;

            return result;
        }
    }
}
