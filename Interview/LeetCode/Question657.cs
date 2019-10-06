using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question657
    {
        public static void EntryPoint()
        {
            (new Question657()).JudgeCircle("UD");
        }

        public bool JudgeCircle(string moves)
        {
            if (moves == null || moves == string.Empty)
                return true;

            Hashtable hash = new Hashtable();
            int countU = 0, countD = 0, countR = 0, countL = 0;

            foreach (var item in moves)
                if (hash.Contains(item))
                    hash[item] = (int)hash[item] + 1;
                else
                    hash.Add(item, 1);

            if (hash.Contains('U'))
                countU = (int)hash['U'];

            if (hash.Contains('D'))
                countD = (int)hash['D'];

            if (hash.Contains('R'))
                countR = (int)hash['R'];

            if (hash.Contains('L'))
                countL = (int)hash['L'];

            if (countU - countD != 0 || countR - countL != 0)
                return false;

            return true;
        }
    }
}