using PhysicalTetris.Creator;
using PhysicalTetris.Input;
using UnityEngine;

namespace PhysicalTetris.Model
{
    public class FactoryModel
    {
        private readonly CreatorGameProcess[] _creatorsGameProcesses = new CreatorGameProcess[2];
        private readonly CreatorScoreCounter[] _creatorScoreCounters = new CreatorScoreCounter[2];

        public FactoryModel()
        {
            _creatorsGameProcesses[0] = new CreatorHeightRatingGame();
            _creatorsGameProcesses[1] = new CreatorWeightRatingGame();

            _creatorScoreCounters[0] = new CreatorHeightCounter();
            _creatorScoreCounters[1] = new CreatorTimeCounter();
        }

        public GameProcess CreateGameProcess(Camera camera, LossPolicy lossPolicy, PoolFigures figuresManager, IScoreCounter scoreCounter, Pause pause, InputRouter inputRouter, Timer timer)
        {
            foreach (var creator in _creatorsGameProcesses)
            {
                if (creator.GameType == DataTransmitter.GameType)
                    return creator.Create(camera, lossPolicy, figuresManager, scoreCounter, pause, inputRouter, timer);
            }

            return null;
        }

        public IScoreCounter CreateScoreCounter()
        {
            foreach (var creator in _creatorScoreCounters)
            {
                if (creator.GameType == DataTransmitter.GameType)
                    return creator.Create();
            }

            return null;
        }

        public Movement CreateMovementHorizontal(Transform minPosition, Transform maxPosition, Transform startPosition)
        {
            Movement movement = new MovementHorizontal(minPosition, maxPosition, startPosition, Config.MovementHorizontalSpeed, Config.MaxBoostHorizontalSpeed,
                    Config.MoveDirectionHorizontal, Config.HorizontalSpeedStep);

            return movement;
        }

        public Movement CreateMovementVertical(Transform minPosition, Transform maxPosition, Transform startPosition)
        {
            Movement movement = new MovementVertical(minPosition, maxPosition, startPosition, Config.MovementVerticalSpeed, Config.MaxBoostVerticalSpeed,
                    Config.MoveDirectionVertical, Config.VerticalSpeedStep);

            return movement;
        }

        public Rotatore CreateRotatore()
        {
            Rotatore rotatore = new Rotatore(Config.RotateSpeed);

            return rotatore;
        }
    }
}

