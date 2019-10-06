using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question359
    {

    }

    public class Logger
    {
        Hashtable hash = null;

        public Logger()
        {
            hash = new Hashtable();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!hash.Contains(message))
            {
                hash.Add(message, timestamp);

                return true;
            }
            else
            {
                if (timestamp - (int)hash[message] >= 10)
                {
                    hash[message] = timestamp;
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
