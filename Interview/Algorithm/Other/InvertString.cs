using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Algorithm.Other
{
    class InvertString
    {
        public void EntryPoint()
        {
            Invert("i ekil siht margorp yrev hcum");
        }

        public void Invert(string input)
        {
            if (input == null || input == string.Empty)
                return;

            int head = 0, tail = input.Length - 1;
            char[] tempChar = input.ToCharArray();

            while (head < tail)
            {
                tempChar[head] ^= tempChar[tail];
                tempChar[tail] ^= tempChar[head];
                tempChar[head] ^= tempChar[tail];

                head++;
                tail--;
            }

            Console.WriteLine(new string(tempChar));
        }
    }
}
