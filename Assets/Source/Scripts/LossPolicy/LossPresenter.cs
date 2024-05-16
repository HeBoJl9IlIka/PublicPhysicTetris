using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public abstract class LossPresenter : MonoBehaviour
    {
        protected LossPolicy _model;

        public abstract Config.LossType LossType { get; }

        public void Init(LossPolicy model)
        {
            _model = model;
            enabled = true;
        }

        private void OnEnable()
        {
            _model.Lost += OnLost;
        }

        private void OnDisable()
        {
            _model.Lost -= OnLost;
        }

        private void OnLost()
        {
            //gameObject.SetActive(false);
        }
    }
}
