using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question66
    {
        public int[] PlusOne(int[] digits)
        {
            int carrier = 0, index = digits.Length - 2, tempResult = 0;
            int[] tempResults = new int[digits.Length];

            tempResult = digits[digits.Length - 1] + 1;

            if (tempResult >= 10)
            {
                tempResults[digits.Length - 1] = tempResult % 10;
                carrier = 1;
            }
            else
                tempResults[digits.Length - 1] = tempResult;

            while (index >= 0)
            {
                tempResult = digits[index] + carrier;

                if (tempResult >= 10)
                    tempResults[index] = tempResult % 10;
                else
                {
                    tempResults[index] = tempResult;
                    carrier = 0;
                }

                index--;
            }

            if (carrier > 0)
            {
                int[] tempResultsWithCarrier = new int[digits.Length + 1];

                tempResultsWithCarrier[0] = 1;

                for (int i = 0; i <= tempResults.Length - 1; i++)
                    tempResultsWithCarrier[i + 1] = tempResults[i];

                return tempResultsWithCarrier;
            }
            else
                return tempResults;
        }
    }
}