using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class LossDropPresenter : LossPresenter
    {
        public override Config.LossType LossType => Config.LossType.Drop;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PhysicManagerPresenter physicManager))
            {
                if (physicManager.Velocity > Config.MaxFigureVelocity)
                {
                    _model.SetStateLossTrigger();
                }
            }
        }
    }
}
