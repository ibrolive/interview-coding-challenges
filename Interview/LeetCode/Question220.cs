using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question220
    {
        public static void EntryPoint()
        {
            //(new Question220()).ContainsNearbyAlmostDuplicate(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3);
            //(new Question220()).ContainsNearbyAlmostDuplicate(new int[] { 1, 2, 3, 1 }, 3, 0);
            (new Question220()).ContainsNearbyAlmostDuplicate(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 4, 3);
        }

        // https://leetcode.com/problems/contains-duplicate-iii/discuss/61645/AC-O(N)-solution-in-Java-using-buckets-with-explanation
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (k < 1 || t < 0) return false;
            Dictionary<long, long> map = new Dictionary<long, long>();
            for (int i = 0; i < nums.Length; i++)
            {
                long remappedNum = (long)nums[i] - Int32.MinValue;
                long bucket = remappedNum / ((long)t + 1);
                if ((map.ContainsKey(bucket) && remappedNum - map[bucket] <= t)
                        || (map.ContainsKey(bucket - 1) && remappedNum - map[bucket - 1] <= t)
                            || (map.ContainsKey(bucket + 1) && map[bucket + 1] - remappedNum <= t))
                    return true;
                if (map.Count >= k)
                {
                    long lastBucket = ((long)nums[i - k] - Int32.MinValue) / ((long)t + 1);
                    map.Remove(lastBucket);
                }

                map.Add(bucket, remappedNum);
            }

            return false;
        }
    }
}
