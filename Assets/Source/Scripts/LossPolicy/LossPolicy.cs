using System;

namespace PhysicalTetris.Model
{
    public class LossPolicy : IUpdatable
    {
        private readonly PoolFigures _poolFigures;

        public bool IsEnabled { get; private set; }

        public event Action Lost;

        public LossPolicy(PoolFigures poolFigures)
        {
            _poolFigures = poolFigures;
        }

        public void Enable()
        {
            IsEnabled = true;

            _poolFigures.ReachedMinVerticalPosition += OnReachedMinVerticalPosition;
        }

        public void Disable()
        {
            IsEnabled = false;

            _poolFigures.ReachedMinVerticalPosition -= OnReachedMinVerticalPosition;
        }

        public void Update(float tick)
        {
            if (IsEnabled == false)
                return;
        }

        public void SetStateLossTrigger()
        {
            Lost?.Invoke();
        }

        private void OnReachedMinVerticalPosition()
        {
            Lost?.Invoke();
        }
    }
}
