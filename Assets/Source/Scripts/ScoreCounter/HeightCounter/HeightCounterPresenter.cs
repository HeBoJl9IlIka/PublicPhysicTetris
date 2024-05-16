using DG.Tweening;
using PhysicalTetris.Model;
using System;
using TMPro;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class HeightCounterPresenter : ScoreCounterPresenter
    {
        [SerializeField] private TMP_Text _currentHeight;

        private HeightCounter _model;

        public override Config.GameType GameType => Config.GameType.HeightRatingGame;

        public override void Init(IScoreCounter scoreCounter, float targetPointY)
        {
            if (scoreCounter is HeightCounter == false)
                throw new ArgumentNullException(nameof(scoreCounter));

            _model = (HeightCounter)scoreCounter;
            transform.position = new Vector2(0, targetPointY);
            enabled = true;
        }

        private void OnEnable()
        {
            _model.MovedMark += OnMovedMark;
        }

        private void OnDisable()
        {
            _model.MovedMark -= OnMovedMark;
        }

        private void OnMovedMark(float currentPoint)
        {
            transform.DOMoveY(currentPoint, Config.LineMaxHeightDurationAnimation);
            _currentHeight.text = currentPoint.ToString("#");
        }
    }
}
