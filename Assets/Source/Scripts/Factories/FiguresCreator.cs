using PhysicalTetris.Input;
using PhysicalTetris.Presenter;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class FiguresCreator
    {
        private readonly FiguresRandomizer _randomizer;
        private readonly FactoryModel _factoryModel;
        private readonly FactoryPresenters _factoryPresenters;
        private readonly Transform _minPoint;
        private readonly Transform _maxPoint;
        private readonly Transform _pointSpawn;

        public InputRouter InputRouter { get; private set; }
        public Movement MovementVertical { get; private set; }
        public Movement MovementHorizontal { get; private set; }
        public Rotatore Rotatore { get; private set; }

        public FiguresCreator(FiguresRandomizer randomizer, FactoryModel factoryModel,
            FactoryPresenters factoryPresenters, Transform minPoint, Transform maxPoint, Transform pointSpawn)
        {
            _randomizer = randomizer;
            _factoryModel = factoryModel;
            _factoryPresenters = factoryPresenters;
            _minPoint = minPoint;
            _maxPoint = maxPoint;
            _pointSpawn = pointSpawn;

            CreateControl();
            InputRouter = new InputRouter(MovementHorizontal, MovementVertical, Rotatore);
        }

        public FigurePresenter CreateFigure(PoolFigures poolFigures)
        {
            FigurePresenter figurePresenter;
            Config.FigureType typeFigure = _randomizer.GetRandomFigure();
            figurePresenter = _factoryPresenters.CreateFigure(poolFigures, MovementVertical, MovementHorizontal, Rotatore, typeFigure, _pointSpawn.position);
            figurePresenter.gameObject.SetActive(false);

            return figurePresenter;
        }

        private void CreateControl()
        {
            MovementVertical = _factoryModel.CreateMovementVertical(_minPoint, _maxPoint, _pointSpawn);
            MovementHorizontal = _factoryModel.CreateMovementHorizontal(_minPoint, _maxPoint, _pointSpawn);
            Rotatore = _factoryModel.CreateRotatore();
        }
    }
}
