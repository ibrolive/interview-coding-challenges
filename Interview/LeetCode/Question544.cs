using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question544
    {
        public static void EntryPoint()
        {
            (new Question544()).FindContestMatch(8);
        }

        public string FindContestMatch(int n)
        {
            List<string> leftSection = new List<string>(),
                         rightSection = new List<string>();

            for (int i = 1, j = n; i <= j; i++, j--)
            {
                leftSection.Add(i.ToString());

                if (i != j)
                    rightSection.Add(j.ToString());
            }

            return GenerateGroup(leftSection, rightSection);
        }
        private string GenerateGroup(List<string> leftSection, List<string> rightSection)
        {
            StringBuilder temp = new StringBuilder();
            List<string> nextLeftSection = new List<string>(),
                         nextRightSection = new List<string>();
            bool flag = true;

            while (leftSection.Count > 0 && rightSection.Count > 0)
            {
                if (flag)
                {
                    temp.Append("(")
                        .Append(leftSection[0])
                        .Append(",")
                        .Append(rightSection[0])
                        .Append(")");

                    flag = false;
                    leftSection.RemoveAt(0);
                    rightSection.RemoveAt(0);
                    nextLeftSection.Add(temp.ToString());
                    temp.Clear();
                }
                else
                {
                    temp.Append("(")
                        .Append(leftSection[leftSection.Count - 1])
                        .Append(",")
                        .Append(rightSection[rightSection.Count - 1])
                        .Append(")");

                    flag = true;
                    leftSection.RemoveAt(leftSection.Count - 1);
                    rightSection.RemoveAt(rightSection.Count - 1);
                    nextRightSection.Add(temp.ToString());
                    temp.Clear();
                }
            }

            if (nextRightSection.Count == 0)
                return nextLeftSection[0];
            else
                return GenerateGroup(nextLeftSection, nextRightSection);
        }
    }
}
