namespace PhysicalTetris.Model
{
    public interface IScoreCounter : IUpdatable
    {
        public abstract float Score { get; }
    }
}
