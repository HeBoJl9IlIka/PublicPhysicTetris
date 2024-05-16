using PhysicalTetris.Input;
using PhysicalTetris.Presenter;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class WeightRatingGame : GameProcess
    {
        public override Config.GameType GameType => Config.GameType.WeightRatingGame;

        public WeightRatingGame(Camera camera, LossPolicy lossPolicy, PoolFigures figuresManager, IScoreCounter scoreCounter, Pause pause, InputRouter inputRouter, Timer timer) : base(camera, lossPolicy, figuresManager, scoreCounter, pause, inputRouter, timer)
        {
        }

        protected override void StartGame()
        {
            CreateFigure();
        }

        protected override void ApplyNextStep(FigurePresenter figurePresenter)
        {
            CreateFigure();
        }

        protected override void EnableFinishScreen()
        {
            DisableInactiveFigures();
            CountFigures();
            CountReward();
            FreezeAllFigures();
        }
    }
}
