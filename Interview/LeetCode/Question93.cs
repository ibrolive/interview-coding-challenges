using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question93
    {
        // https://leetcode.com/problems/restore-ip-addresses/discuss/30972/WHO-CAN-BEAT-THIS-CODE
        public IList<string> RestoreIpAddresses(string s)
        {
            IList<string> result = new List<string>();
            int section1 = 0,
                section2 = 0,
                section3 = 0,
                section4 = 0;

            for (int a = 1; a <= 3; a++)
                for (int b = 1; b <= 3; b++)
                    for (int c = 1; c <= 3; c++)
                        for (int d = 1; d <= 3; d++)
                            if (a + b + c + d == s.Length)
                            {
                                section1 = Convert.ToInt32(s.Substring(0, a));
                                section2 = Convert.ToInt32(s.Substring(a, b));
                                section3 = Convert.ToInt32(s.Substring(a + b, c));
                                section4 = Convert.ToInt32(s.Substring(a + b + c, d));

                                if (section1 <= 255 && section2 <= 255 && section3 < 255 && section4 <= 255 &&
                                   (section1.ToString() + "." + section2.ToString() + "." + section3.ToString() + "." + section4.ToString()).Length == s.Length + 3)
                                    result.Add(section1.ToString() + "." + section2.ToString() + "." + section3.ToString() + "." + section4.ToString());
                            }

            return result;
        }
    }
}
