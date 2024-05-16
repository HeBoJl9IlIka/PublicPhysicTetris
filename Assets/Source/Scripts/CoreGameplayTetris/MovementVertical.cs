using UnityEngine;

namespace PhysicalTetris.Model
{
    public class MovementVertical : Movement
    {
        protected override Config.MovementType _movementType => Config.MovementType.Vertical;

        public MovementVertical(Transform minPosition, Transform maxPosition, Transform startPosition, float moveSpeed,
            float maxBoostSpeed, float moveDirection, float speedStep) : base(minPosition, maxPosition, startPosition,
                moveSpeed, maxBoostSpeed, moveDirection, speedStep)
        {
        }
    }
}
