using PhysicalTetris.Input;
using PhysicalTetris.Presenter;
using System;

namespace PhysicalTetris.Model
{
    public abstract class GameProcess : IUpdatable
    {
        private readonly Camera _camera;
        private readonly LossPolicy _lossPolicy;
        private readonly PoolFigures _poolFigures;
        private readonly IScoreCounter _scoreCounter;
        private readonly Pause _pause;
        private readonly InputRouter _inputRouter;
        private readonly Timer _timer;
        private bool _isStartedGame;

        public abstract Config.GameType GameType { get; }
        public int Score => (int)_scoreCounter.Score;
        public int AmountFigures { get; private set; }
        public int Reward { get; private set; }
        public bool IsEnabled { get; private set; }

        public event Action<FigurePresenter> FigureSetted;
        public event Action Lost;

        public GameProcess(Camera camera, LossPolicy lossPolicy, PoolFigures figuresManager, IScoreCounter scoreCounter, Pause pause, InputRouter inputRouter, Timer timer)
        {
            _camera = camera;
            _lossPolicy = lossPolicy;
            _poolFigures = figuresManager;
            _scoreCounter = scoreCounter;
            _pause = pause;
            _inputRouter = inputRouter;
            _timer = timer;
        }

        public void Enable()
        {
            IsEnabled = true;
            _poolFigures.Enable();
            _scoreCounter.Enable();
            _lossPolicy.Enable();
            _inputRouter.Enable();
            _timer.Enable();

            _lossPolicy.Lost += OnLost;
            _poolFigures.Collised += OnCollised;
            _timer.TimerExpired += OnTimerExpired;
        }

        public void Disable()
        {
            IsEnabled = false;
            _poolFigures.Disable();
            _scoreCounter.Disable();
            _lossPolicy.Disable();
            _inputRouter.Disable();
            _timer.Disable();

            _lossPolicy.Lost -= OnLost;
            _poolFigures.Collised -= OnCollised;
            _timer.TimerExpired -= OnTimerExpired;
        }

        public void Update(float tick)
        {
            if (IsEnabled == false)
                return;

            if (_pause.IsPaused)
                return;

            if (_isStartedGame)
                _scoreCounter.Update(tick);

            _poolFigures.Update(tick);
            _timer.Update(tick);
        }

        protected abstract void StartGame();
        protected abstract void ApplyNextStep(FigurePresenter figurePresenter);
        protected abstract void EnableFinishScreen();

        protected void StopGame() => IsEnabled = false;
        protected void CreateFigure() => _poolFigures.GetFigure();
        protected void MoveVerticalCamera() => _camera.MoveVertical(_scoreCounter.Score);
        protected void ZoomOutCamera() => _camera.ZoomOut(_scoreCounter.Score);
        protected void FreezeAllFigures() => _poolFigures.FreezeAllFigures();
        protected void GetHighestPoint() => _poolFigures.GetHighestPoint();
        protected int CountFigures() => AmountFigures = _poolFigures.CountFigures();
        protected void DisableInactiveFigures() => _poolFigures.DisableInactiveFigures();

        protected void MoveMark(FigurePresenter figurePresenter)
        {
            if (GameType != Config.GameType.HeightRatingGame)
                return;

            if (_scoreCounter is HeightCounter == false)
                throw new ArgumentNullException(nameof(HeightCounter));

            HeightCounter heightCounter = (HeightCounter)_scoreCounter;
            heightCounter.MoveMark(figurePresenter);
        }

        protected void StopTimer()
        {
            if (GameType == Config.GameType.HeightRatingGame)
                return;

            if (_scoreCounter is TimeCounter == false)
                throw new ArgumentNullException(nameof(TimeCounter));

            TimeCounter timeCounter = (TimeCounter)_scoreCounter;
            timeCounter.Disable();
        }

        protected void CountReward()
        {
            if (DataTransmitter.GameType == Config.GameType.HeightRatingGame)
                Reward = AmountFigures * (int)_scoreCounter.Score;

            if (DataTransmitter.GameType == Config.GameType.WeightRatingGame)
            {
                int points = AmountFigures * Config.GameProcessMultiplierAmountFigures;
                int points1 = points / Score;
                Reward = points1 * AmountFigures;
            }
        }

        private void OnLost()
        {
            _pause.Stop();
            StopGame();
            EnableFinishScreen();
            Lost?.Invoke();
        }

        private void OnCollised(FigurePresenter figurePresenter)
        {
            if (IsEnabled == false)
                return;

            FigureSetted?.Invoke(figurePresenter);
            ApplyNextStep(figurePresenter);
        }

        private void OnTimerExpired()
        {
            StartGame();
            _isStartedGame = true;
        }
    }
}
