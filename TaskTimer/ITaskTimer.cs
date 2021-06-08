using System;

namespace TaskTimer
{
    public interface ITaskTimer
    {
        void StartTimer();

        void PauseTimer();

        event EventHandler Tick;
    }
}
