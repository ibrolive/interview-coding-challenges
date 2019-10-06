using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.LeetCode
{
    class Question151
    {
        public string ReverseWords(string s)
        {
            if (s == null || s == string.Empty)
                return s;

            string[] array = s.Split(' ');
            StringBuilder output = new StringBuilder();

            for (int i = array.Length - 1; i >= 0; i--)
                if (array[i] != string.Empty)
                    output.Append(array[i] + " ");

            return output.ToString() == string.Empty ? string.Empty : output.Remove(output.Length - 1, 1).ToString();
        }
    }
}