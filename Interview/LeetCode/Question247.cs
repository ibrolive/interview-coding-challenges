using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question247
    {
        public static void EntryPoint()
        {
            (new Question247()).FindStrobogrammatic(3);
        }

        char[] leadingNumbers = new char[] { '0', '1', '8', '6', '9' },
               tailingNumbers = new char[] { '0', '1', '8', '9', '6' };

        public IList<string> FindStrobogrammatic(int n)
        {
            IList<string> result = new List<string>();

            Helper(result, new char[n], 0);

            return result;
        }

        private void Helper(IList<string> result, char[] previous, int index)
        {
            if (previous.Length % 2 == 0 && index > (previous.Length - 1) / 2)
            {
                result.Add(new String(previous));

                return;
            }
            else if (previous.Length % 2 != 0 && index == (previous.Length - 1) / 2)
            {
                for (int j = 0; j < 3; j++)
                {
                    previous[(previous.Length - 1) / 2] = leadingNumbers[j];

                    result.Add(new String(previous));
                }

                return;
            }

            if (index == 0)
            {
                for (int i = 1; i < leadingNumbers.Length; i++)
                {
                    previous[index] = leadingNumbers[i];
                    previous[previous.Length - index - 1] = tailingNumbers[i];

                    Helper(result, previous, index + 1);
                }
            }
            else
            {
                for (int i = 0; i < leadingNumbers.Length; i++)
                {
                    previous[index] = leadingNumbers[i];
                    previous[previous.Length - index - 1] = tailingNumbers[i];

                    Helper(result, previous, index + 1);
                }
            }
        }
    }
}
