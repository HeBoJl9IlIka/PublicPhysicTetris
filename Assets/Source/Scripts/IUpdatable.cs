namespace PhysicalTetris.Model
{
    public interface IUpdatable
    {
        public bool IsEnabled { get; }

        void Enable();
        void Disable();
        void Update(float tick);
    }
}
