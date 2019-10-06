using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Question819
    {
        public static void EntryPoint()
        {
            (new Question819()).MostCommonWord("Bob hit a ball the hit BALL flew far after it was hit. ", new string[] { "hit" });
        }

        public string MostCommonWord(string paragraph, string[] banned)
        {
            Hashtable hashtable = new Hashtable();
            string[] splitedWords = paragraph.Split(' ');
            int max = Int32.MinValue;
            bool isBanned = false;
            string temp, result = string.Empty;

            foreach (var item in splitedWords)
            {
                if (item.Trim() != string.Empty)
                {
                    if (!((item[item.Length - 1] >= 65 && item[item.Length - 1] <= 90) || (item[item.Length - 1] >= 97 && item[item.Length - 1] <= 122)))
                        temp = item.Remove(item.Length - 1, 1);
                    else
                        temp = item;

                    if (!hashtable.ContainsKey(temp.ToUpper()))
                        hashtable.Add(temp.ToUpper(), 1);
                    else
                        hashtable[temp.ToUpper()] = ((int)hashtable[temp.ToUpper()]) + 1;
                }
            }

            foreach (var key in hashtable.Keys)
            {
                foreach (var bannedWord in banned)
                    if (bannedWord.ToUpper() == (string)key)
                        isBanned = true;

                if (!isBanned)
                    if ((int)hashtable[key] > max)
                    {
                        max = (int)hashtable[key];
                        result = (string)key;
                    }

                isBanned = false;
            }

            return result.ToLower();
        }
    }
}
