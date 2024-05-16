using PhysicalTetris.Model;

namespace PhysicalTetris.Creator
{
    public abstract class CreatorScoreCounter
    {
        public abstract Config.GameType GameType { get; }

        public abstract IScoreCounter Create();
    }

    public class CreatorHeightCounter : CreatorScoreCounter
    {
        public override Config.GameType GameType => Config.GameType.HeightRatingGame;

        public override IScoreCounter Create()
        {
            return new HeightCounter();
        }
    }

    public class CreatorTimeCounter : CreatorScoreCounter
    {
        public override Config.GameType GameType => Config.GameType.WeightRatingGame;

        public override IScoreCounter Create()
        {
            return new TimeCounter();
        }
    }
}
