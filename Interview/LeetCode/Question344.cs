using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question344
    {
        public static void EntryPoint()
        {
            Console.WriteLine((new Question344()).ReverseString("Hello"));
        }

        public string ReverseString(string s)
        {
            if (s == string.Empty)
                return s;

            char[] array = s.ToCharArray();
            char temp;
            int i = 0, j = array.Length - 1;

            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;

                i++;
                j--;
            }

            return new string(array);
        }
    }
}
