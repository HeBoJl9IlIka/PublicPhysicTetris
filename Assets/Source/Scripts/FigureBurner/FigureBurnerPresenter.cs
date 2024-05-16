using DG.Tweening;
using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class FigureBurnerPresenter : MonoBehaviour
    {
        [SerializeField] private Color _targetBlinkColor;
        [SerializeField] private Color _targetBurntColor;

        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private LossTouchPresenter _lossTouch;
        private Tween _tweenBurnt;
        private float _time;
        private bool _isBurning;

        public bool IsBurning => _isBurning;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (_isBurning == false)
                return;

            _time += Time.deltaTime;

            if (_time >= Config.TimeToLose)
            {
                _lossTouch.ReportLoss();
                _isBurning = false;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_isBurning)
                return;

            if (collision.TryGetComponent(out LossTouchPresenter lossTouch))
            {
                _lossTouch = lossTouch;

                if (_rigidbody2D.bodyType == RigidbodyType2D.Dynamic)
                {
                    _isBurning = true;
                    _tweenBurnt = _spriteRenderer.DOColor(_targetBurntColor, Config.TimeToLose);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out LossTouchPresenter lossTouch))
            {
                _isBurning = false;
                _tweenBurnt.Pause();
            }
        }
    }
}
