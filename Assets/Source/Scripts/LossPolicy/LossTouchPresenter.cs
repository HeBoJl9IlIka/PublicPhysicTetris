using PhysicalTetris.Model;

namespace PhysicalTetris.Presenter
{
    public class LossTouchPresenter : LossPresenter
    {
        public override Config.LossType LossType => Config.LossType.Touch;

        public void ReportLoss()
        {
            _model.SetStateLossTrigger();
        }
    }
}
