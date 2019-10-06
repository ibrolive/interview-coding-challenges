using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1115
    {
    }

    public class FooBar
    {
        private int n;
        private System.Threading.Semaphore foo = new System.Threading.Semaphore(1, 1),
                                           bar = new System.Threading.Semaphore(0, 1);

        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                foo.WaitOne();

                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();

                bar.Release();
            }
        }

        public void Bar(Action printBar)
        {
            for (int i = 0; i < n; i++)
            {
                bar.WaitOne();

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                foo.Release();
            }
        }
    }
}
