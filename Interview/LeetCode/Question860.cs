using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question860
    {
        public bool LemonadeChange(int[] bills)
        {
            int count5 = 0,
                count10 = 0;

            foreach (var item in bills)
                if (item == 20)
                {
                    if ((count5 < 3 && count10 == 0) || (count10 != 0 && count5 == 0))
                        return false;
                    else if (count10 == 0)
                        count5 -= 3;
                    else if (count10 != 0)
                    {
                        count10--;
                        count5--;
                    }
                }
                else if (item == 10)
                {
                    if (count5 == 0)
                        return false;

                    count10++;
                    count5--;
                }
                else if (item == 5)
                    count5++;

            return true;
        }
    }
}
