using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class FiguresFixerPresenter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                if (rigidbody2D.velocity.magnitude <= Config.MaxFigureVelocity)
                    rigidbody2D.freezeRotation = true;
            }
        }
    }
}
