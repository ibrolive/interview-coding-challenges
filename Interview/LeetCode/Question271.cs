using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question271
    {
        public static void EntryPoint()
        {
            Codec translater = new Codec();

            translater.decode(translater.encode(new string[] { "#" }));
        }
    }

    public class Codec
    {
        public string encode(IList<string> strs)
        {
            if (strs.Count == 0)
                return null;

            StringBuilder result = new StringBuilder();

            foreach (var item in strs)
                result.Append(item.Replace("#", "##") + " # ");

            return result.Length != 0 ? result.Remove(result.Length - 3, 3).ToString() : string.Empty;
        }

        public IList<string> decode(string s)
        {
            if (s == null)
                return new List<string>();

            string[] temp = s.Split(new string[] { " # " }, StringSplitOptions.None);
            List<string> result = new List<string>();

            if (s == string.Empty)
                result.Add("");
            else
                foreach (var item in temp)
                    result.Add(item.Replace("##", "#"));

            return result;
        }
    }
}
