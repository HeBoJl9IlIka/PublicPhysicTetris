using PhysicalTetris.Input;
using PhysicalTetris.Presenter;

namespace PhysicalTetris.Model
{
    public class HeightRatingGame : GameProcess
    {
        public override Config.GameType GameType => Config.GameType.HeightRatingGame;

        public HeightRatingGame(Camera camera, LossPolicy lossPolicy, PoolFigures figuresManager, IScoreCounter scoreCounter, Pause pause, InputRouter inputRouter, Timer timer) : base(camera, lossPolicy, figuresManager, scoreCounter, pause, inputRouter, timer)
        {
        }

        protected override void StartGame()
        {
            CreateFigure();
        }

        protected override void ApplyNextStep(FigurePresenter figurePresenter)
        {
            MoveMark(figurePresenter);
            MoveVerticalCamera();
            CreateFigure();
        }

        protected override void EnableFinishScreen()
        {
            CountFigures();
            CountReward();
            FreezeAllFigures();
            ZoomOutCamera();
        }
    }
}
