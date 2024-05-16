using System;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class Rotatore : IUpdatable
    {
        private float _currentAngle;
        private float _targetAngle;
        private float _rotationStep;

        public bool IsEnabled { get; private set; }

        public event Action<float> Rotated;

        public Rotatore(float rotationStep)
        {
            _rotationStep = rotationStep;
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

            if (_currentAngle != _targetAngle)
            {
                _currentAngle = Mathf.Lerp(_currentAngle, _targetAngle, _rotationStep * tick);
                Rotated?.Invoke(_currentAngle);
            }
        }

        public void Rotate()
        {
            _targetAngle += Config.AngleRotate;
        }
    }
}
