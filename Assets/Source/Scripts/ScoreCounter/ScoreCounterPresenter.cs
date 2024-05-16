using PhysicalTetris.Model;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public abstract class ScoreCounterPresenter : MonoBehaviour
    {
        public abstract Config.GameType GameType { get; }

        public abstract void Init(IScoreCounter scoreCounter, float targetPointY);
    }
}
