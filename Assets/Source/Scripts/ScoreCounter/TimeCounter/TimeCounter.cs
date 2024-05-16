namespace PhysicalTetris.Model
{
    public class TimeCounter : IScoreCounter
    {
        public float Score { get; private set; }
        public bool IsEnabled { get; private set; }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }

        public void Update(float tick)
        {
            if (IsEnabled == false)
                return;

            Score += tick;
        }
    }
}