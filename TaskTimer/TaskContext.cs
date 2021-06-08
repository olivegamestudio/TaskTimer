using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TaskTimer
{
    public class TaskContext : INotifyPropertyChanged
    {
        readonly TaskModel _model;

        public TimeSpan TimeElapsed
        {
            get => _model.TimeElapsed;
            set
            {
                _model.TimeElapsed = value;
                OnPropertyChanged(nameof(TimeElapsed));
            }
        }

        readonly ITaskTimer _timer = new TaskDispatcherTimer();

        public TaskContext(TaskModel model)
        {
            _model = model;
            StartCommand = new StartCommand(_timer);
            PauseCommand = new PauseCommand(_timer);
            ResetCommand = new ResetCommand(_model);
            _timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            TimeElapsed += TimeSpan.FromSeconds(1);
        }

        public ICommand StartCommand { get; }

        public ICommand PauseCommand { get; }

        public ICommand ResetCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}