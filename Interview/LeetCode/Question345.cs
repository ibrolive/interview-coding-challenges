using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question345
    {
        public string ReverseVowels(string s)
        {
            HashSet<char> vowels = new HashSet<char>();
            char[] array = s.ToCharArray();
            char temp;
            int start = 0,
                end = s.Length - 1;
            bool startvowel = false,
                 endvowel = false;

            vowels.Add('a');
            vowels.Add('e');
            vowels.Add('i');
            vowels.Add('o');
            vowels.Add('u');
            vowels.Add('A');
            vowels.Add('E');
            vowels.Add('I');
            vowels.Add('O');
            vowels.Add('U');

            while (start < end)
            {
                if (vowels.Contains(array[start]))
                    startvowel = true;
                else
                    start++;

                if (vowels.Contains(array[end]))
                    endvowel = true;
                else
                    end--;

                if (startvowel && endvowel)
                {
                    temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;

                    startvowel = false;
                    endvowel = false;

                    start++;
                    end--;
                }
            }

            return new string(array);
        }
    }
}