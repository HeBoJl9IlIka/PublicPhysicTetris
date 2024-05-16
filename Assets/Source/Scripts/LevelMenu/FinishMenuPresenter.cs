using PhysicalTetris.Model;
using System;
using TMPro;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public abstract class FinishMenuPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mapName;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _countFigures;
        [SerializeField] private TMP_Text _reward;

        private ContainerPresenter _container;

        private GameProcess _gameProcess;

        public abstract Config.GameType GameType { get; }

        private void Awake()
        {
            _container = GetComponentInChildren<ContainerPresenter>();

            if (_container == null)
                throw new ArgumentNullException(nameof(ContainerPresenter));

            _mapName.text = DataTransmitter.MapName.ToString();
            _container.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _gameProcess.Lost += OnLost;
        }

        private void OnDisable()
        {
            _gameProcess.Lost -= OnLost;
        }

        public void Init(GameProcess gameProcess)
        {
            _gameProcess = gameProcess;
            enabled = true;
        }

        private void OnLost()
        {
            Invoke(nameof(Show), Config.FinishMenuDelayShow);
        }

        private void Show()
        {
            _score.text = _gameProcess.Score.ToString();
            _countFigures.text = _gameProcess.AmountFigures.ToString();
            _reward.text = _gameProcess.Reward.ToString();
            _container.gameObject.SetActive(true);
        }
    }
}
