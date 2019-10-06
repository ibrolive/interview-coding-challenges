using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question6
    {
        public static void EntryPoint()
        {
            (new Question6()).Convert1("0123456789", 4);
        }

        public string Convert1(string s, int numRows)
        {
            if (s.Length <= 2 || numRows == 1)
                return s;

            StringBuilder sb = new StringBuilder();
            int space = numRows * 2 - 2;

            for (int i = numRows; i >= 1; i--)
            {
                int gap = i * 2 - 2, start = numRows - i;

                while (start < s.Length)
                {
                    sb.Append(s[start]); // down
                    if ((gap != space && gap != 0) && (start + gap) < s.Length)
                        sb.Append(s[start + gap]); //up

                    start = start + space;
                }
            }

            return sb.ToString();
        }

        public string Convert2(string s, int numRows)
        {
            if (s == null || s.Length == 0 || numRows == 0) { return ""; }
            if (numRows == 1) { return s; }
            string[] ss = new string[numRows];
            for (int i = 0; i <= numRows - 1; i++) { ss[i] = ""; }
            int row = 0; bool down = true;
            for (int i = 0; i <= s.Length - 1; i++)
            {
                ss[row] += s[i].ToString();
                if (row == numRows - 1) { row--; down = false; }
                else if (row == 0) { row++; down = true; }
                else if (down) { row++; }
                else if (!down) { row--; }
            }
            string r = "";
            foreach (string str in ss)
            { r += str; }
            return r;
        }
    }
}