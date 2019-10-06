using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question165
    {
        public static void EntryPoint()
        {
            (new Question165()).CompareVersion("1", "1.1");
        }

        public int CompareVersion(string version1, string version2)
        {
            if (version1 == null || version1.Length == 0 ||
                version2 == null || version2.Length == 0 ||
                version1 == version2)
                return 0;

            string[] subVersion1 = version1.Split('.'),
                     subVersion2 = version2.Split('.');
            int index1 = 0,
                index2 = 0;
            bool onlyZero = true;

            while (index1 < subVersion1.Length && index2 < subVersion2.Length)
            {
                if (index1 == 0 &&
                    index2 == 0 &&
                    ((Convert.ToInt32(subVersion1[index1])).ToString().Length != subVersion1[index1].Length ||
                     (Convert.ToInt32(subVersion2[index2])).ToString().Length != subVersion2[index2].Length))
                    return 0;
                else if (Convert.ToInt32(subVersion1[index1]) > Convert.ToInt32(subVersion2[index2]))
                    return 1;
                else if (Convert.ToInt32(subVersion1[index1]) < Convert.ToInt32(subVersion2[index2]))
                    return -1;

                index1++;
                index2++;
            }

            if (index1 < subVersion1.Length)
            {
                while (index1 < subVersion1.Length)
                    if (Convert.ToInt32(subVersion1[index1]) != 0)
                    {
                        onlyZero = false;
                        break;
                    }
                    else
                        index1++;

                if (!onlyZero)
                    return 1;
            }

            if (index2 < subVersion2.Length)
            {
                while (index2 < subVersion2.Length)
                    if (Convert.ToInt32(subVersion2[index2]) != 0)
                    {
                        onlyZero = false;
                        break;
                    }
                    else
                        index2++;

                if (!onlyZero)
                    return -1;
            }

            return 0;
        }
    }
}
