using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicManagerPresenter : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private bool _isFreeFall;

        public float Velocity => _rigidbody2D.velocity.magnitude;
        public bool IsDynamic => _rigidbody2D.bodyType == RigidbodyType2D.Dynamic;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }

        private void OnDisable()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out FigurePresenter figure))
                _isFreeFall = false;

            if (collision.TryGetComponent(out GroundPresenter ground))
                _isFreeFall = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out FigurePresenter figure))
                Invoke(nameof(IncreaseDrag), Config.DelayToActiveteDrag);

            if (collision.TryGetComponent(out GroundPresenter ground))
                Invoke(nameof(IncreaseDrag), Config.DelayToActiveteDrag);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _isFreeFall = true;
            _rigidbody2D.drag = Config.RigidbodyDefaultDrag;
            _rigidbody2D.angularDrag = Config.RigidbodyDefaultAngularDrag;
        }

        public void Freeze()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        private void IncreaseDrag()
        {
            if (_isFreeFall)
                return;

            _rigidbody2D.drag = Config.RigidbodyActiveDrag;
            _rigidbody2D.angularDrag = Config.RigidbodyActiveAngularDrag;
        }
    }
}
