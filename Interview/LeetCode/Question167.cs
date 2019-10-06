using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question167
    {
        public static void EntryPoint()
        {
            (new Question167()).TwoSum(new int[] { 2, 3, 4 }, 6);
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            Hashtable hashtable = new Hashtable();
            List<int> temp = null;

            for (int i = 0; i < numbers.Length; i++)
                if (!hashtable.ContainsKey(numbers[i]))
                {
                    temp = new List<int>();
                    temp.Add(i);
                    hashtable.Add(numbers[i], temp);
                }
                else
                    ((List<int>)hashtable[numbers[i]]).Add(i);

            foreach (var item in hashtable.Keys)
                if (hashtable.ContainsKey(target - (int)item))
                {
                    if (((List<int>)hashtable[item]).Count > 1)
                    {
                        result[0] = ((List<int>)hashtable[item])[0] + 1;
                        result[1] = ((List<int>)hashtable[item])[1] + 1;
                    }
                    else
                    {
                        result[0] = ((List<int>)hashtable[item])[0] + 1;
                        result[1] = ((List<int>)hashtable[target - (int)item])[0] + 1;
                    }

                    break;
                }

            if (result[0] > result[1])
            {
                result[0] += result[1];
                result[1] = result[0] - result[1];
                result[0] = result[0] - result[1];
            }


            return result;
        }
    }
}
