using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public abstract class PausePresenter : MonoBehaviour
    {
        private Pause _model;

        protected bool IsPaused => _model.IsPaused;

        public void Init(Pause pause)
        {
            _model = pause;
            enabled = true;
        }

        private void OnEnable()
        {
            _model.Playing += OnPlaying;
            _model.Stopped += OnStopped;
            Enable();
        }

        private void OnDisable()
        {
            _model.Playing -= OnPlaying;
            _model.Stopped -= OnStopped;
            Disable();
        }

        protected void Play()
        {
            _model.Play();
            _model.PlayTime();
        }

        protected void Stop()
        {
            _model.Stop();
            _model.StopTime();
        }

        protected abstract void Enable();
        protected abstract void Disable();

        protected virtual void OnPlaying(){}
        protected virtual void OnStopped(){}
    }
}
