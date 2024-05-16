using System;

namespace PhysicalTetris.Model
{
    public class FiguresRandomizer
    {
        private int _countTypesFigures;
        private int _lastNumberFigure;
        private int _numberOfRepeat;

        public FiguresRandomizer()
        {
            _countTypesFigures = Enum.GetNames(typeof(Config.FigureType)).Length;
        }

        public Config.FigureType GetRandomFigure()
        {
            int numberTypeFigure = UnityEngine.Random.Range(0, _countTypesFigures);

            if (_numberOfRepeat >= Config.RandomizerMaxRepeat)
            {
                while (_lastNumberFigure == numberTypeFigure)
                    numberTypeFigure = UnityEngine.Random.Range(0, _countTypesFigures);

                _numberOfRepeat = 0;
            }

            _lastNumberFigure = numberTypeFigure;
            ++_numberOfRepeat;

            return (Config.FigureType)numberTypeFigure;
        }
    }
}
