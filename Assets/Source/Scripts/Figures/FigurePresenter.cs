using PhysicalTetris.Model;
using System;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    [RequireComponent(typeof(CollidersManagerPresenter))]
    [RequireComponent(typeof(PhysicManagerPresenter))]
    [RequireComponent(typeof(FigureBurnerPresenter))]
    public class FigurePresenter : MonoBehaviour
    {
        [SerializeField] private Config.FigureType _typeFigure;
        [SerializeField] private Transform[] _raycastPoints;
        [SerializeField] private LayerMask _layerMask;

        private PoolFigures _figuresManager;
        private Movement _modelMovementVertical;
        private Movement _modelMovementHorizontal;
        private Rotatore _modelRotatore;
        private CollidersManagerPresenter _colliderManager;
        private PhysicManagerPresenter _physicManager;
        private FigureBurnerPresenter _figureBurner;
        private bool _isActive = true;

        public Config.FigureType TypeFigure => _typeFigure;
        public bool IsBurning => _figureBurner.IsBurning;
        public bool IsDynamic => _physicManager.IsDynamic;
        public float LastVelocity { get; private set; }

        public event Action Collised;

        private void Awake()
        {
            _colliderManager = GetComponent<CollidersManagerPresenter>();
            _physicManager = GetComponent<PhysicManagerPresenter>();
            _figureBurner = GetComponent<FigureBurnerPresenter>();
        }

        private void OnEnable()
        {
            _modelRotatore.Rotated += OnRotated;
            _figuresManager.FreezedAllFigures += OnFreezedAllFigures;
        }

        private void OnDisable()
        {
            _modelRotatore.Rotated -= OnRotated;
            _figuresManager.FreezedAllFigures -= OnFreezedAllFigures;
        }

        private void Update()
        {
            if (_physicManager.IsDynamic)
                LastVelocity = _physicManager.Velocity;

            if (_isActive == false)
                return;

            if (_modelMovementHorizontal.IsBoosting)
                enabled = CanMove();

            transform.position = new Vector2(_modelMovementHorizontal.CurrentPosition, _modelMovementVertical.CurrentPosition);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isActive == false)
                return;

            if (collision.TryGetComponent(out FigurePresenter figure))
            {
                Collised?.Invoke();
                MakeInactive();
            }

            if (collision.TryGetComponent(out GroundPresenter ground))
            {
                Collised?.Invoke();
                MakeInactive();
            }
        }

        public void Init(PoolFigures figuresManager, Movement modelMovementVertical, Movement modelMovementHorizontal, Rotatore modelRotatore)
        {
            _figuresManager = figuresManager;
            _modelMovementVertical = modelMovementVertical;
            _modelMovementHorizontal = modelMovementHorizontal;
            _modelRotatore = modelRotatore;
            enabled = true;
        }

        private void OnRotated(float angle)
        {
            if (_isActive == false)
                return;

            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        private bool CanMove()
        {
            foreach (var point in _raycastPoints)
            {
                RaycastHit2D raycastLeftHit2D = Physics2D.Raycast(point.position, Vector2.left, Config.FigureDistanceRaycast, _layerMask);
                RaycastHit2D raycastRightHit2D = Physics2D.Raycast(point.position, Vector2.right, Config.FigureDistanceRaycast, _layerMask);
                bool isCollider = raycastLeftHit2D.collider != null || raycastRightHit2D.collider != null;

                if (isCollider)
                    return isCollider ? false : true;
            }

            return true;
        }

        private void OnFreezedAllFigures()
        {
            _physicManager.Freeze();
        }

        private void MakeInactive()
        {
            _isActive = false;
            gameObject.layer = Config.LayerDefault;
            _colliderManager.enabled = false;
            _physicManager.enabled = false;
        }
    }
}
