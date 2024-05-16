using PhysicalTetris.Model;
using System;
using TMPro;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class TimeCounterPresenter : ScoreCounterPresenter
    {
        [SerializeField] private TMP_Text _currentTime;

        private TimeCounter _model;

        public override Config.GameType GameType => Config.GameType.WeightRatingGame;

        public override void Init(IScoreCounter scoreCounter, float targetPointY)
        {
            if (scoreCounter is TimeCounter == false)
                throw new ArgumentNullException(nameof(scoreCounter));

            _model = (TimeCounter)scoreCounter;
            enabled = true;
        }

        private void Update()
        {
            _currentTime.text = _model.Score.ToString("#.#");
        }
    }
}
