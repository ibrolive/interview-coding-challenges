using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question535
    {

    }

    public class CodecQuestion535
    {
        Hashtable hash1 = new Hashtable(),
                  hash2 = new Hashtable();
        string shortStringSource = "abcdefthijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string encode(string longUrl)
        {
            StringBuilder shortString = new StringBuilder();

            if (longUrl == null || longUrl == string.Empty)
                return string.Empty;
            else if (hash1.ContainsKey(longUrl))
                return (string)hash1[longUrl];

            for (int i = 0; i <= 5; i++)
                shortString.Append(shortStringSource[new Random().Next(0, 61)]);

            hash1.Add(longUrl, "http://tinyurl.com/" + shortString.ToString());
            hash2.Add("http://tinyurl.com/" + shortString.ToString(), longUrl);

            return "http://tinyurl.com/" + shortString.ToString();
        }

        public string decode(string shortUrl)
        {
            return (string)hash2[shortUrl];
        }
    }
}