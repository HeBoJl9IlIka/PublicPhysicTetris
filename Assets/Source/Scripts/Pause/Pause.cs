using Agava.WebUtility;
using System;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class Pause : IUpdatable
    {
        public bool IsPaused { get; private set; }

        public bool IsEnabled { get; private set; }

        public event Action Playing;
        public event Action Stopped;

        public void Enable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeEvent;
        }

        public void Disable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeEvent;
        }

        public void Update(float tick) { }

        public void Play()
        {
            IsPaused = false;
            Playing?.Invoke();
        }

        public void Stop()
        {
            IsPaused = true;
            Stopped?.Invoke();
        }

        public void PlayTime() => Time.timeScale = 1;
        public void StopTime() => Time.timeScale = 0;

        private void OnInBackgroundChangeEvent(bool inBackground)
        {
            if (inBackground)
            {
                Stop();
                StopTime();
            }
        }
    }
}
