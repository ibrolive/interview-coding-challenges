using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1114
    {

    }

    public class Foo
    {
        private System.Threading.Semaphore second = new System.Threading.Semaphore(0, 1),
                                           third = new System.Threading.Semaphore(0, 1);

        public Foo()
        {

        }

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();

            this.second.Release();
        }

        public void Second(Action printSecond)
        {
            this.second.WaitOne();

            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();

            this.third.Release();
        }

        public void Third(Action printThird)
        {
            this.third.WaitOne();

            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
}
