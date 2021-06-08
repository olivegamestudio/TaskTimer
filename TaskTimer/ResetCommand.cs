using System;
using System.Windows.Input;

namespace TaskTimer
{
    public class ResetCommand : ICommand
    {
        readonly TaskModel _model;

        public ResetCommand(TaskModel model)
        {
            _model = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _model.TimeElapsed = TimeSpan.Zero;
        }

        public event EventHandler CanExecuteChanged;
    }
}
