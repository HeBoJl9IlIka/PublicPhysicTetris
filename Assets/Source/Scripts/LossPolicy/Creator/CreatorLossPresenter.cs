using PhysicalTetris.Model;
using PhysicalTetris.Presenter;
using System.Linq;
using System;
using UnityEngine;

namespace PhysicalTetris.Creator
{
    public abstract class CreatorLossPresenter
    {
        public abstract Config.GameType GameType { get; }

        public abstract LossPolicy Create(LossPresenter[] lossPresenters, PoolFigures figuresManager, Transform lossContainer, float targetPointY);
    }

    public class CreatorLossForHeightGame : CreatorLossPresenter
    {
        public override Config.GameType GameType => Config.GameType.HeightRatingGame;

        public override LossPolicy Create(LossPresenter[] lossPresenters, PoolFigures figuresManager, Transform lossContainer, float targetPointY)
        {
            LossPresenter template = lossPresenters.FirstOrDefault(newLoss => newLoss.LossType == Config.LossType.Drop);

            if (template == null)
                throw new ArgumentNullException(nameof(template));

            LossPolicy newPolicyLoss = new LossPolicy(figuresManager);
            LossPresenter newLoss = MonoBehaviour.Instantiate(template, lossContainer);
            newLoss.Init(newPolicyLoss);

            return newPolicyLoss;
        }
    }

    public class CreatorLossForWeightGame : CreatorLossPresenter
    {
        public override Config.GameType GameType => Config.GameType.WeightRatingGame;

        public override LossPolicy Create(LossPresenter[] lossPresenters, PoolFigures figuresManager, Transform lossContainer, float targetPointY)
        {
            LossPresenter templateDrop = lossPresenters.FirstOrDefault(templateDrop => templateDrop.LossType == Config.LossType.Drop);
            LossPresenter templateTouch = lossPresenters.FirstOrDefault(templateTouch => templateTouch.LossType == Config.LossType.Touch);

            if (templateDrop == null)
                throw new ArgumentNullException(nameof(templateDrop));

            if (templateTouch == null)
                throw new ArgumentNullException(nameof(templateTouch));

            LossPolicy newPolicyLoss = new LossPolicy(figuresManager);
            LossPresenter newLossDrop = MonoBehaviour.Instantiate(templateDrop, lossContainer);
            newLossDrop.Init(newPolicyLoss);
            LossPresenter newLossTouch = MonoBehaviour.Instantiate(templateTouch, lossContainer);
            newLossTouch.Init(newPolicyLoss);
            newLossTouch.transform.position = new Vector2(0, targetPointY);

            return newPolicyLoss;
        }
    }
}