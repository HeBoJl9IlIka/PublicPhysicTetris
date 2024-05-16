using PhysicalTetris.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class PoolFigures : IUpdatable
    {
        private readonly FiguresCreator _figuresCreator;
        private readonly List<FigurePresenter> _figuresPresenters;
        private readonly List<IUpdatable> _updatables;
        private List<FigurePresenter> _currentActiveFigures;
        private FigurePresenter _currentFigurePresenter;
        private Movement _movementHorizontal;
        private Movement _movementVertical;
        private Rotatore _rotatore;
        private float _maxHeight;
        private float _maxVerticalPosition;

        public bool IsEnabled { get; private set; }

        public event Action<FigurePresenter> Collised;
        public event Action ReachedMinVerticalPosition;
        public event Action FreezedAllFigures;

        public PoolFigures(FiguresCreator figuresCreator, float maxVerticalPosition)
        {
            _figuresCreator = figuresCreator;
            _maxVerticalPosition = maxVerticalPosition;

            _figuresPresenters = new List<FigurePresenter>();
            _updatables = new List<IUpdatable>();
            _currentActiveFigures = new List<FigurePresenter>();

            CreatePool();
            SetControl();
        }

        public void Enable()
        {
            IsEnabled = true;

            _movementVertical.Enable();
            _movementHorizontal.Enable();
            _rotatore.Enable();

            _movementVertical.ReachedMinPosition += OnReachedMinPosition;

            foreach (var figure in _figuresPresenters)
                figure.Collised += OnCollised;
        }

        public void Disable()
        {
            IsEnabled = false;

            _movementVertical.Disable();
            _movementHorizontal.Disable();
            _rotatore.Disable();

            _movementVertical.ReachedMinPosition -= OnReachedMinPosition;

            foreach (var figure in _figuresPresenters)
                figure.Collised -= OnCollised;
        }

        public void Update(float tick)
        {
            if (IsEnabled == false)
                return;

            foreach (var updatable in _updatables)
            {
                if (updatable != null)
                    updatable.Update(tick);
            }

            if (_movementHorizontal.IsBoosting)
                _movementVertical.Disable();
            else
                _movementVertical.Enable();
        }

        public FigurePresenter GetFigure()
        {
            _currentFigurePresenter = _figuresPresenters.FirstOrDefault(figure => figure.gameObject.activeSelf == false);

            if (_currentFigurePresenter == null)
                throw new ArgumentException("The figures are over");

            ResetFigure();
            _currentFigurePresenter.gameObject.SetActive(true);

            return _currentFigurePresenter;
        }

        public void FreezeAllFigures()
        {
            FreezedAllFigures?.Invoke();
        }

        public float GetHighestPoint()
        {
            _maxHeight = _currentFigurePresenter.transform.position.y;

            foreach (var figure in _figuresPresenters)
            {
                if (_maxHeight < figure.transform.position.y)
                    _maxHeight = figure.transform.position.y;
            }

            return _maxHeight;
        }

        public int CountFigures()
        {
            int count = 0;

            if (DataTransmitter.GameType == Config.GameType.HeightRatingGame)
                _maxVerticalPosition = GetHighestPoint();

            foreach (var figure in _figuresPresenters)
            {
                if (figure.gameObject.activeSelf)
                {
                    if (figure.IsDynamic)
                    {
                        if (figure.transform.position.y < _maxVerticalPosition)
                        {
                            if (figure.LastVelocity < Config.MaxFigureVelocity)
                            {
                                if (figure.IsBurning == false)
                                    count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

        public void DisableInactiveFigures()
        {
            foreach (var figure in _figuresPresenters)
            {
                if (figure == _currentFigurePresenter)
                    figure.gameObject.SetActive(false);

                if (figure.gameObject.activeSelf)
                {
                    if (figure.LastVelocity > Config.MaxFigureVelocity)
                        figure.gameObject.SetActive(false);

                    if (figure.IsBurning)
                        figure.gameObject.SetActive(false);
                }
            }
        }

        private void CreatePool()
        {
            for (int i = 0; i < Config.PoolCountFigures; i++)
            {
                FigurePresenter figurePresenter = _figuresCreator.CreateFigure(this);
                _figuresPresenters.Add(figurePresenter);
            }
        }

        private void SetControl()
        {
            _movementVertical = _figuresCreator.MovementVertical;
            _movementHorizontal = _figuresCreator.MovementHorizontal;
            _rotatore = _figuresCreator.Rotatore;

            _updatables.Add(_movementVertical);
            _updatables.Add(_movementHorizontal);
            _updatables.Add(_rotatore);
        }

        private void ResetFigure()
        {
            _movementVertical.Reset();
            _movementHorizontal.Reset();
        }

        private void OnCollised()
        {
            Collised?.Invoke(_currentFigurePresenter);
        }
        private void OnReachedMinPosition()
        {
            ReachedMinVerticalPosition?.Invoke();
        }
    }
}
