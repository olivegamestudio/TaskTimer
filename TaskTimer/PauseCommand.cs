using System;
using System.Windows.Input;

namespace TaskTimer
{
    public class PauseCommand : ICommand
    {
        readonly ITaskTimer _timer;

        public PauseCommand(ITaskTimer timer)
        {
            _timer = timer;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _timer.PauseTimer();
        }

        public event EventHandler CanExecuteChanged;
    }
}
