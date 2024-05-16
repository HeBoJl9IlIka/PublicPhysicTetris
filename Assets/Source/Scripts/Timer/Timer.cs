using System;

namespace PhysicalTetris.Model
{
    public class Timer : IUpdatable
    {
        public float Time { get; private set; }
        public bool IsEnabled { get; private set; }

        public event Action TimerExpired;

        public Timer(float targetTime)
        {
            Time = targetTime;
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }

        public void Update(float tick)
        {
            if (IsEnabled == false)
                return;

            Time -= tick;

            if (Time <= 0)
            {
                TimerExpired?.Invoke();
                IsEnabled = false;
            }
        }
    }
}
