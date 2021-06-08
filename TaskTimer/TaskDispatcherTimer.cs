using System;
using System.Windows.Threading;

namespace TaskTimer
{
    public class TaskDispatcherTimer : ITaskTimer
    {
        readonly DispatcherTimer _timer;

        public TaskDispatcherTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) => Tick.Invoke(this, EventArgs.Empty);
        }

        public void StartTimer()
        {
            _timer.Start();
        }

        public void PauseTimer()
        {
            _timer.Stop();
        }

        public event EventHandler Tick = delegate { };
    }
}
