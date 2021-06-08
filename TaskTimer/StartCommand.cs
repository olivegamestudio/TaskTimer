using System;
using System.Windows.Input;

namespace TaskTimer
{
    public class StartCommand : ICommand
    {
        readonly ITaskTimer _timer;

        public StartCommand(ITaskTimer timer)
        {
            _timer = timer;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _timer.StartTimer();
        }

        public event EventHandler CanExecuteChanged;
    }
}
