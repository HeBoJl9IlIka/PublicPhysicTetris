using PhysicalTetris.Model;
using System;
using static UnityEngine.InputSystem.InputAction;

namespace PhysicalTetris.Input
{
    public class InputRouter
    {
        private readonly PlayerInput _input;
        private Movement _movementHorizontal;
        private Movement _movementVertical;
        private Rotatore _rotatore;
        private float _boostDirection;

        public InputRouter(Movement movementHorizontal, Movement movementVertical, Rotatore rotatore)
        {
            _input = new PlayerInput();

            _movementHorizontal = movementHorizontal;
            _movementVertical = movementVertical;
            _rotatore = rotatore;
        }

        public void Enable()
        {
            _input.Enable();
            _input.PlayerOne.MoveHorizontal.started += PlayerOneOnMovedHorizontal;
            _input.PlayerOne.MoveHorizontal.canceled += PlayerOneOnMovedHorizontal;
            _input.PlayerOne.BoostHorizontal.started += PlayerOneOnBoostedHorizontal;
            _input.PlayerOne.BoostHorizontal.performed += PlayerOneOnBoostedHorizontal;
            _input.PlayerOne.BoostVertical.started += PlayerOneOnBoostedVertical;
            _input.PlayerOne.BoostVertical.canceled += PlayerOneOnBoostedVertical;
            _input.PlayerOne.RotateFigure.performed += PlayerOneOnRotatedFigure;
        }

        public void Disable()
        {
            _input.Disable();
            _input.PlayerOne.MoveHorizontal.started -= PlayerOneOnMovedHorizontal;
            _input.PlayerOne.MoveHorizontal.canceled -= PlayerOneOnMovedHorizontal;
            _input.PlayerOne.BoostHorizontal.started -= PlayerOneOnBoostedHorizontal;
            _input.PlayerOne.BoostHorizontal.performed -= PlayerOneOnBoostedHorizontal;
            _input.PlayerOne.BoostVertical.started -= PlayerOneOnBoostedVertical;
            _input.PlayerOne.BoostVertical.canceled -= PlayerOneOnBoostedVertical;
            _input.PlayerOne.RotateFigure.performed -= PlayerOneOnRotatedFigure;
        }

        private void PlayerOneOnMovedHorizontal(CallbackContext obj)
        {
            _movementHorizontal.SetDirectionMove(obj.ReadValue<float>());
        }

        private void PlayerOneOnBoostedHorizontal(CallbackContext obj)
        {
            if (obj.started)
                _boostDirection = obj.ReadValue<float>();

            if (obj.performed)
                _movementHorizontal.SetDirectionBoost(_boostDirection);
        }

        private void PlayerOneOnBoostedVertical(CallbackContext obj)
        {
            _movementVertical.SetDirectionBoost(obj.ReadValue<float>());
        }

        private void PlayerOneOnRotatedFigure(CallbackContext obj)
        {
            _rotatore.Rotate();
        }
    }
}
