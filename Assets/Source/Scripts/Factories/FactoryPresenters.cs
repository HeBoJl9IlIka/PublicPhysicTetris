using PhysicalTetris.Creator;
using PhysicalTetris.Model;
using System;
using System.Linq;
using UnityEngine;

namespace PhysicalTetris.Presenter
{
    public class FactoryPresenters : MonoBehaviour
    {
        [SerializeField] private FigurePresenter[] _figureTemplates;
        [SerializeField] private Transform _figuresContainer;
        [SerializeField] private LossPresenter[] _lossTemplates;
        [SerializeField] private Transform _lossContainer;
        [SerializeField] private ScoreCounterPresenter[] _scoreCounterTemplates;
        [SerializeField] private Transform _scoreCounterContainer;
        [SerializeField] private FinishMenuPresenter[] _finishMenuTemplates;
        [SerializeField] private TimerPresenter _timerTemplate;
        [SerializeField] private PauseMenuPresenter _pauseMenuTemplate;
        [SerializeField] private Transform _uiContainer;

        public FigurePresenter CreateFigure(PoolFigures figuresManager, Movement movementVertical, Movement movementHorizontal, Rotatore rotatore, Config.FigureType typeFigure, Vector2 position)
        {
            FigurePresenter template = _figureTemplates.FirstOrDefault(template => template.TypeFigure == typeFigure);

            if (template == null)
                throw new ArgumentNullException(nameof(typeFigure));

            FigurePresenter newFigure = Instantiate(template, position, new Quaternion(0, 0, 0, 0), _figuresContainer);
            newFigure.Init(figuresManager, movementVertical, movementHorizontal, rotatore);

            return newFigure;
        }

        public LossPolicy CreateLoss(PoolFigures figuresManager, float maxHeightPoint)
        {
            CreatorLossPresenter[] creatorsLossPresenters = new CreatorLossPresenter[2];
            creatorsLossPresenters[0] = new CreatorLossForHeightGame();
            creatorsLossPresenters[1] = new CreatorLossForWeightGame();

            CreatorLossPresenter creatorLoss = creatorsLossPresenters.FirstOrDefault(creatorLoss => creatorLoss.GameType == DataTransmitter.GameType);

            if (creatorLoss == null)
                throw new ArgumentNullException(nameof(creatorLoss));

            return creatorLoss.Create(_lossTemplates, figuresManager, _lossContainer, maxHeightPoint);
        }

        public ScoreCounterPresenter CreateScoreCounter(IScoreCounter scoreCounter, float targetPointY)
        {
            ScoreCounterPresenter template = _scoreCounterTemplates.FirstOrDefault(template => template.GameType == DataTransmitter.GameType);

            if (template == null)
                throw new ArgumentNullException(nameof(template));

            Quaternion rotation = new Quaternion(0, 0, 0, 0);
            Vector2 position = new Vector2(0, targetPointY);
            ScoreCounterPresenter newScoreCounter = Instantiate(template, position, rotation, _scoreCounterContainer);
            newScoreCounter.Init(scoreCounter, targetPointY);

            return newScoreCounter;
        }

        public FinishMenuPresenter CreateFinishMenu(GameProcess gameProcess)
        {
            FinishMenuPresenter template = _finishMenuTemplates.FirstOrDefault(template => template.GameType == gameProcess.GameType);

            if (template == null)
                throw new ArgumentNullException(nameof(template));

            FinishMenuPresenter newFinishMenu = Instantiate(template, _uiContainer);
            newFinishMenu.Init(gameProcess);

            return newFinishMenu;
        }

        public TimerPresenter CreateTimer(Timer timer)
        {
            if (_timerTemplate == null)
                throw new ArgumentNullException(nameof(_timerTemplate));

            TimerPresenter newTimer = Instantiate(_timerTemplate, _uiContainer);
            newTimer.Init(timer);

            return newTimer;
        }

        public PauseMenuPresenter CreatePauseMenu(Pause pause)
        {
            if (_pauseMenuTemplate == null)
                throw new ArgumentNullException(nameof(_pauseMenuTemplate));

            PauseMenuPresenter newPause = Instantiate(_pauseMenuTemplate, _uiContainer);
            newPause.Init(pause);

            return newPause;
        }
    }
}
