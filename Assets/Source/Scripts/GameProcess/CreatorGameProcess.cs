using PhysicalTetris.Input;
using PhysicalTetris.Model;

namespace PhysicalTetris.Creator
{
    public abstract class CreatorGameProcess
    {
        public abstract Config.GameType GameType { get; }

        public abstract GameProcess Create(Camera camera, LossPolicy lossPolicy, PoolFigures figuresManager, IScoreCounter scoreCounter, Pause pause, InputRouter inputRouter, Timer timer);
    }

    public class CreatorHeightRatingGame : CreatorGameProcess
    {
        public override Config.GameType GameType => Config.GameType.HeightRatingGame;

        public override GameProcess Create(Camera camera, LossPolicy lossPolicy, PoolFigures figuresManager, IScoreCounter scoreCounter, Pause pause, InputRouter inputRouter, Timer timer)
        {
            return new HeightRatingGame(camera, lossPolicy, figuresManager, scoreCounter, pause, inputRouter, timer);
        }
    }

    public class CreatorWeightRatingGame : CreatorGameProcess
    {
        public override Config.GameType GameType => Config.GameType.WeightRatingGame;

        public override GameProcess Create(Camera camera, LossPolicy lossPolicy, PoolFigures figuresManager, IScoreCounter scoreCounter, Pause pause, InputRouter inputRouter, Timer timer)
        {
            return new WeightRatingGame(camera, lossPolicy, figuresManager, scoreCounter, pause, inputRouter, timer);
        }
    }
}