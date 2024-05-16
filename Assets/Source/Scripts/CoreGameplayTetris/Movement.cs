using System;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public abstract class Movement : IUpdatable
    {
        protected abstract Config.MovementType _movementType { get; }

        private Transform _startPosition;
        private Transform _minPosition;
        private Transform _maxPosition;
        private float _moveSpeed;
        private float _boostSpeed;
        private float _maxBoostSpeed;
        private float _moveDirection;
        private float _boostDirection;
        private float _speedBoostStep;

        public float CurrentPosition { get; private set; }
        public bool IsBoosting { get; private set; }
        public bool IsEnabled { get; private set; }
        public bool HasMaxPosition => _movementType == Config.MovementType.Horizontal ? CurrentPosition >= _maxPosition.position.x : CurrentPosition >= _maxPosition.position.y;
        public bool HasMinPosition => _movementType == Config.MovementType.Horizontal ? CurrentPosition <= _minPosition.position.x : CurrentPosition <= _minPosition.position.y;

        public event Action ReachedMinPosition;

        public Movement(Transform minPosition, Transform maxPosition, Transform startPosition, float moveSpeed, float maxBoostSpeed, float moveDirection, float speedStep)
        {
            _minPosition = minPosition;
            _maxPosition = maxPosition;
            _startPosition = startPosition;
            _moveSpeed = moveSpeed;
            _maxBoostSpeed = maxBoostSpeed;
            _moveDirection = moveDirection;
            _speedBoostStep = speedStep;
            CurrentPosition = _movementType == Config.MovementType.Horizontal ? _startPosition.position.x : _startPosition.position.y;
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

            if (HasMinPosition || HasMaxPosition)
                IsBoosting = false;

            ChangeBoost();
            Move(tick);
            ClampMove();
        }

        public void Reset()
        {
            IsBoosting = false;
            CurrentPosition = _movementType == Config.MovementType.Horizontal ? _startPosition.position.x : _startPosition.position.y;
        }

        public void SetDirectionMove(float value)
        {
            _moveDirection = value;
        }

        public void SetDirectionBoost(float value)
        {
            _boostDirection = value;
            IsBoosting = value != 0;
        }

        private void Move(float tick)
        {
            if (IsBoosting)
                CurrentPosition += (_moveSpeed + _boostSpeed) * _boostDirection * tick;
            else
                CurrentPosition += _moveSpeed * _moveDirection * tick;
        }

        private void ClampMove()
        {
            if (HasMinPosition)
            {
                CurrentPosition = _movementType == Config.MovementType.Horizontal ? _minPosition.position.x : _minPosition.position.y;
                ReachedMinPosition?.Invoke();
            }

            if (HasMaxPosition)
                CurrentPosition = _movementType == Config.MovementType.Horizontal ? _maxPosition.position.x : _maxPosition.position.y;
        }

        private void ChangeBoost()
        {
            if (IsBoosting)
            {
                if (_boostSpeed < _maxBoostSpeed)
                    _boostSpeed += _speedBoostStep;
            }
            else
            {
                _boostSpeed = 0;
            }
        }
    }
}
