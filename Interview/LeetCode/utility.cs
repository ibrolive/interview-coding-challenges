using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    public class utility
    {
        public static int[][] ConvertStringToIntArray(string s)
        {
            string[] array = s.Replace("],[", "|").Replace(" ", string.Empty).Replace("[", "").Replace("]", "").Split('|');
            int[][] result = new int[array.Length][];

            for (int i = 0; i < result.Length; i++)
            {
                string[] tempArray = array[i].Trim().Split(',');
                List<int> current = new List<int>();

                foreach (var item in tempArray)
                    current.Add(Convert.ToInt32(item));

                result[i] = current.ToArray<int>();
            }

            return result;
        }
    }
}
