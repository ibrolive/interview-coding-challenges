using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question18
    {
        public static void EntryPoint()
        {
            (new Question18()).FourSum(new int[] { 0, 0, 0, 0 }, 0);
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> tempList = new List<int>();
            int num1Index = 0,
                num2Index = 0,
                num3Index = 0,
                num4Index = 0,
                sum = 0;

            Array.Sort(nums);

            if (nums != null || nums.Length != 0)
            {
                for (num1Index = 0; num1Index < nums.Length - 3; num1Index++)
                {
                    if (num1Index > 0 && nums[num1Index - 1] == nums[num1Index])
                        continue;

                    for (num2Index = num1Index + 1; num2Index < nums.Length - 2; num2Index++)
                    {
                        if (num2Index - 1 != num1Index && nums[num2Index - 1] == nums[num2Index])
                            continue;

                        num3Index = num2Index + 1;
                        num4Index = nums.Length - 1;

                        while (num3Index < num4Index)
                        {
                            if (num3Index - 1 != num2Index && nums[num3Index - 1] == nums[num3Index])
                            {
                                num3Index++;
                                continue;
                            }
                            else if (num4Index + 1 != nums.Length && nums[num4Index + 1] == nums[num4Index])
                            {
                                num4Index--;
                                continue;
                            }

                            sum = nums[num1Index] + nums[num2Index] + nums[num3Index] + nums[num4Index];

                            if (sum == target)
                            {
                                tempList = new List<int>();
                                tempList.Add(nums[num1Index]);
                                tempList.Add(nums[num2Index]);
                                tempList.Add(nums[num3Index]);
                                tempList.Add(nums[num4Index]);

                                result.Add(tempList);

                                num3Index++;
                                num4Index--;
                            }
                            else if (sum < target)
                                num3Index++;
                            else if (sum > target)
                                num4Index--;
                        }
                    }
                }
            }

            return result;
        }
    }
}