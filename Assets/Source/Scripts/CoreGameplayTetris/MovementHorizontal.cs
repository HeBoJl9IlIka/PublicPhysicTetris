using UnityEngine;

namespace PhysicalTetris.Model
{
    public class MovementHorizontal : Movement
    {
        protected override Config.MovementType _movementType => Config.MovementType.Horizontal;

        public MovementHorizontal(Transform minPosition, Transform maxPosition, Transform startPosition, float moveSpeed,
            float maxBoostSpeed, float moveDirection, float speedStep) : base(minPosition, maxPosition, startPosition,
                moveSpeed, maxBoostSpeed, moveDirection, speedStep)
        {
        }
    }
}
