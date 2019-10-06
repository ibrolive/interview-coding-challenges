using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question307
    {

    }

    public class NumArrayQuestion307
    {
        int[] nums;
        int[] BIT;
        int n;

        public NumArrayQuestion307(int[] nums)
        {
            this.nums = nums;

            n = nums.Length;
            BIT = new int[n + 1];
            for (int i = 0; i < n; i++)
                init(i, nums[i]);
        }

        public void init(int i, int val)
        {
            i++;
            while (i <= n)
            {
                BIT[i] += val;
                i += (i & -i);
            }
        }

        public void Update(int i, int val)
        {
            int diff = val - nums[i];
            nums[i] = val;
            init(i, diff);
        }

        public int getSum(int i)
        {
            int sum = 0;
            i++;
            while (i > 0)
            {
                sum += BIT[i];
                i -= (i & -i);
            }
            return sum;
        }

        public int SumRange(int i, int j)
        {
            return getSum(j) - getSum(i - 1);
        }
    }
}
