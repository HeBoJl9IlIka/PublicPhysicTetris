using PhysicalTetris.Presenter;
using System;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class HeightCounter : IScoreCounter
    {
        public float Score { get; private set; }
        public bool IsEnabled { get; private set; }

        public event Action<float> MovedMark;

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
        }

        public void MoveMark(FigurePresenter figurePresenter)
        {
            if (figurePresenter == null)
                return;

            if (figurePresenter.TryGetComponent(out SpriteRenderer spriteRenderer) == false)
                return;

            if (Score > spriteRenderer.bounds.max.y)
                return;

            Score = spriteRenderer.bounds.max.y;
            MovedMark?.Invoke(Score);
        }
    }
}
