using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question500
    {
        public static void EntryPoint()
        {
            (new Question500()).FindWords(new string[] {"Hello", "Alaska", "Dad", "Peace"});
        }

        public string[] FindWords(string[] words)
        {
            if (words == null || words.Length == 0)
                return words;

            string line1 = "QWERTYUIOP";
            string line2 = "ASDFGHJKL";
            string line3 = "ZXCVBNM";
            Hashtable hashLine1 = new Hashtable();
            Hashtable hashLine2 = new Hashtable();
            Hashtable hashLine3 = new Hashtable();
            List<string> tempList = new List<string>();
            bool vailed = true;

            foreach (var item in line1)
                hashLine1.Add(item, null);

            foreach (var item in line2)
                hashLine2.Add(item, null);

            foreach (var item in line3)
                hashLine3.Add(item, null);

            foreach (var item in words)
            {
                if (hashLine1.Contains(item.ToUpper()[0]))
                {
                    foreach (var character in item.ToUpper())
                        if (!hashLine1.Contains(character))
                        {
                            vailed = false;
                            break;
                        }

                    if (vailed)
                        tempList.Add(item);
                }
                else if (hashLine2.Contains(item.ToUpper()[0]))
                {
                    foreach (var character in item.ToUpper())
                        if (!hashLine2.Contains(character))
                        {
                            vailed = false;
                            break;
                        }

                    if (vailed)
                        tempList.Add(item);
                }
                else if (hashLine3.Contains(item.ToUpper()[0]))
                {
                    foreach (var character in item.ToUpper())
                        if (!hashLine3.Contains(character))
                        {
                            vailed = false;
                            break;
                        }

                    if (vailed)
                        tempList.Add(item);
                }

                vailed = true;
            }         

            return tempList.ToArray();
        }
    }
}