using PhysicalTetris.Input;
using PhysicalTetris.Model;
using PhysicalTetris.Presenter;
using System;
using UnityEngine;

[RequireComponent(typeof(FactoryPresenters))]
public class LevelCompositeRoot : MonoBehaviour
{
    [SerializeField] private Transform _minPoint;
    [SerializeField] private Transform _maxPoint;
    [SerializeField] private Transform _pointSpawnFigure;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _maxHeightPoint;
    [SerializeField] private Transform _ground;

    private InputRouter _inputRouter;
    private GameProcess _gameProcess;
    private FactoryPresenters _factoryPresenters;
    private FactoryModel _factoryModel;
    private FiguresRandomizer _figuresRandomizer;
    private FiguresCreator _figuresCreator;
    private PhysicalTetris.Model.Camera _camera;
    private LossPolicy _lossPolicy;
    private PoolFigures _poolFigures;
    private FinishMenuPresenter _finishMenuPresenter;
    private IScoreCounter _scoreCounter;
    private ScoreCounterPresenter _scoreCounterPresenter;
    private Timer _timer;
    private TimerPresenter _timerPresenter;
    private Pause _pause;
    private PauseMenuPresenter _pauseMenuPresenter;

    private void Awake()
    {
        _factoryPresenters = GetComponent<FactoryPresenters>();

        _factoryModel = new FactoryModel();
        _figuresRandomizer = new FiguresRandomizer();
        _figuresCreator = new FiguresCreator(_figuresRandomizer, _factoryModel, _factoryPresenters, _minPoint, _maxPoint, _pointSpawnFigure);
        _inputRouter = _figuresCreator.InputRouter;
        _camera = new PhysicalTetris.Model.Camera(UnityEngine.Camera.main);
        _poolFigures = new PoolFigures(_figuresCreator, _maxHeightPoint.position.y);
        _lossPolicy = _factoryPresenters.CreateLoss(_poolFigures, _maxHeightPoint.position.y);
        _scoreCounter = _factoryModel.CreateScoreCounter();
        _scoreCounterPresenter = _factoryPresenters.CreateScoreCounter(_scoreCounter, _targetPoint.position.y);
        _timer = new Timer(Config.TimeDelayStartGame);
        _timerPresenter = _factoryPresenters.CreateTimer(_timer);
        _pause = new Pause();
        _pauseMenuPresenter = _factoryPresenters.CreatePauseMenu(_pause);

        _gameProcess = _factoryModel.CreateGameProcess(_camera, _lossPolicy, _poolFigures, _scoreCounter, _pause, _inputRouter, _timer);
        _finishMenuPresenter = _factoryPresenters.CreateFinishMenu(_gameProcess);

        if (_gameProcess == null)
            throw new ArgumentNullException(nameof(_gameProcess));
    }

    private void OnEnable()
    {
        _gameProcess.Enable();
    }

    private void OnDisable()
    {
        _gameProcess.Disable();
    }

    private void Update()
    {
        _gameProcess.Update(Time.deltaTime);
    }
}
