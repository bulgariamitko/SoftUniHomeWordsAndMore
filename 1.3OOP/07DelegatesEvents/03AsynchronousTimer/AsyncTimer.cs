using System;
using System.Threading;

namespace _03AsynchronousTimer
{
    public class AsyncTimer
    {
        private Action<DateTime> Action { get; set; }
        private int Ticks { get; set; }
        private int T { get; set; }

        public AsyncTimer(Action<DateTime> action, int ticks, int x)
        {
            Action = action;
            Ticks = ticks;
            T = x;
        }

        public void Run()
        {
            var parallel = new Thread(this.Execute);
            parallel.Start();
        }

        public void Execute()
        {
            for (int i = 0; i < this.Ticks; i++)
            {
                Thread.Sleep(this.T);
                this.Action(DateTime.Now);
            }
        }
    }
}