using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Interview.Thread
{
    // Use multiple-thread to generate the output files:
    // FileA    FileB   FileC   FileD
    // 1        2       3       4
    // 4        1       2       3
    // 3        4       1       2
    // 2        3       4       1
    class Question1
    {
        Queue<string> _content = new Queue<string>();
        int _repeat = 1;
        object _lock = new object();

        public static void EntryPoint()
        {
            (new Question1()).ThreadControl();
        }

        public void ThreadControl()
        {
            _content.Enqueue("1");
            _content.Enqueue("2");
            _content.Enqueue("3");
            _content.Enqueue("4");

            System.Threading.Thread thread1 = new System.Threading.Thread(() =>
            {
                while (_repeat != 4)
                {
                    lock (_lock)
                    {
                        Output("FileA.txt", (_content.ToArray())[0]);
                    }
                }
            });

            System.Threading.Thread thread2 = new System.Threading.Thread(() =>
            {
                while (_repeat != 4)
                {
                    lock (_lock)
                    {
                        Output("FileB.txt", (_content.ToArray())[1]);
                    }
                }
            });

            System.Threading.Thread thread3 = new System.Threading.Thread(() =>
            {
                while (_repeat != 4)
                {
                    lock (_lock)
                    {
                        Output("FileC.txt", (_content.ToArray())[2]);
                    }
                }
            });

            System.Threading.Thread thread4 = new System.Threading.Thread(() =>
            {
                while (_repeat++ != 4)
                {
                    lock (_lock)
                    {
                        Output("FileD.txt", (_content.ToArray())[3]);

                        string temp = _content.Dequeue();
                        _content.Enqueue(temp);
                    }
                }
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
        }

        private void Output(string fileName, string outputContent)
        {
            string filePath = @"C:\Users\roxi\Documents\GitHub\Interview\Interview\Output\" + fileName;
            StreamWriter sw = File.AppendText(filePath);

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            sw.Write(outputContent);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }
}