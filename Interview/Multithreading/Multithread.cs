using System;
using System.Text;

namespace Interview.Thread
{
    class SwitchThreadSample
    {
        private StringBuilder _log = new StringBuilder();
        private string _log2 = string.Empty;
        private static object myLock = new object();

        public static void EntryPoint()
        {
            (new SwitchThreadSample()).Start();
        }

        public void Start()
        {
            System.Threading.Thread thread1 = new System.Threading.Thread(Foo1);
            System.Threading.Thread thread2 = new System.Threading.Thread(Foo2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            System.IO.File.WriteAllText(@"C:\Users\roxi\Documents\GitHub\Interview\Interview\Output\Result.txt", _log2);
        }

        private void Foo1()
        {
            int i = 0;
            lock (myLock)
            {
                while (i < 5000)
                {
                    //_log.Append(i.ToString() + " - Thread1 - " + System.DateTime.Now.Second + " - " + System.DateTime.Now.Millisecond + "\r\n");
                    _log2 += i.ToString() + " - Thread1 - " + System.DateTime.Now.Second + " - " + System.DateTime.Now.Millisecond + "\r\n";
                    i++;
                }
            }

            //_log.Append(i + "\r\n");
            Console.WriteLine(i);
        }

        private void Foo2()
        {
            int i = 0;

            lock (myLock)
            {
                while (i < 5000)
                {
                    //_log.Append(i.ToString() + " - Thread2 - " + System.DateTime.Now.Second + " - " + System.DateTime.Now.Millisecond + "\r\n");
                    _log2 += i.ToString() + " - Thread2 - " + System.DateTime.Now.Second + " - " + System.DateTime.Now.Millisecond + "\r\n";
                    i++;
                }
            }

            //_log.Append(i + "\r\n");
            Console.WriteLine(i);
        }
    }
}