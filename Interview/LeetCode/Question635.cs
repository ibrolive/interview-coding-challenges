using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question635
    {
        public static void EntryPoint()
        {
            LogSystem obj = new LogSystem();

            obj.Put(1, "2017:01:01:23:59:59");
            obj.Put(2, "2017:01:01:22:59:59");
            obj.Put(3, "2016:01:01:00:00:00");

            obj.Retrieve("2016:01:01:01:01:01", "2017:01:01:23:00:00", "Year");
            obj.Retrieve("2016:01:01:01:01:01", "2017:01:01:23:00:00", "Hour");
        }
    }

    public class LogSystem
    {
        Dictionary<int, long> _dictionary = new Dictionary<int, long>();

        public LogSystem()
        {
        }

        public void Put(int id, string timestamp)
        {
            _dictionary.Add(id, Convert.ToInt64(timestamp.Replace(":", "")));
        }

        public IList<int> Retrieve(string s, string e, string gra)
        {
            long start = Convert.ToInt64(s.Replace(":", "")),
                 end = Convert.ToInt64(e.Replace(":", "")),
                 div = 1;

            switch (gra)
            {
                case "Year":
                    div = 10000000000;
                    break;
                case "Month":
                    div = 100000000;
                    break;
                case "Day":
                    div = 1000000;
                    break;
                case "Hour":
                    div = 10000;
                    break;
                case "Minute":
                    div = 100;
                    break;
                case "Second":
                    div = 1;
                    break;
                default:
                    div = 1;
                    break;
            }

            start /= div;
            end /= div;

            return _dictionary.Where(x => x.Value / div >= start && x.Value / div <= end).Select(x => x.Key).ToList();
        }
    }
}
