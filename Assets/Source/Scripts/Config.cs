namespace PhysicalTetris.Model
{
    public static class Config
    {
        public enum MovementType
        {
            Horizontal,
            Vertical
        }

        public enum FigureType
        {
            T,
            Q,
            I,
            Z,
            S,
            J,
            L
        }

        public enum GameType
        {
            HeightRatingGame,
            WeightRatingGame,
            SpeedRatingGame,
            DuoGame
        }

        public enum LossType
        {
            Drop,
            Touch
        }

        public enum SkinType
        {
            Figure,
            Background
        }

        public enum Skin
        {
            Default,
            Lego,
            Wood
        }
        
        public enum MapName
        {
            Crash,
            Rush,
            Burn
        }

        public enum TypeCurrency
        {
            Money,
            Yni
        }

        // Camera
        public const float CameraOffsetPosition = 2;
        public const float CameraMoveDuration = 2;
        public const float CameraZoomOutCoefficient = 1.83f;
        // Figures
        public const int LayerDefault = 0;
        public const int LayerActiveFigure = 6;
        public const float DelayToActiveteDrag = 2;
        public const float RigidbodyDefaultDrag = 1;
        public const float RigidbodyDefaultAngularDrag = 0.25f;
        public const float RigidbodyActiveDrag = 2;
        public const float RigidbodyActiveAngularDrag = 0.5f;
        public const float FigureColliderCompression = 0.15f;
        public const float FigureDistanceRaycast = 0.25f;
        // Movement Vertical
        public const float MovementVerticalSpeed = 1;
        public const float MaxBoostVerticalSpeed = 5;
        public const float MoveDirectionVertical = -1;
        public const float VerticalSpeedStep = 0.03f;
        // Movement Horizontal
        public const float MovementHorizontalSpeed = 2;
        public const float MaxBoostHorizontalSpeed = 30;
        public const float MoveDirectionHorizontal = 0;
        public const float HorizontalSpeedStep = 30;
        // Rotatore
        public const float AngleRotate = -90;
        public const float RotateSpeed = 10;
        // WeightRatingGame
        
        // LineMaxHeight
        public const float LineMaxHeightDurationAnimation = 2;
        public const string Meters = " m.";
        // FiguresRandomizer
        public const int RandomizerMaxRepeat = 1;
        // GameProcess
        public const int GameProcessMultiplierAmountFigures = 700;
        public const float TimeDelayStartGame = 3.5f;
        public const float TimeToLose = 3;
        public const float MaxFigureVelocity = 1.5f;
        // FinishMenu
        public const float FinishMenuDelayShow = 4;
        // FigureBurner
        public const float BurnerBlinkAnimationDuration = 0.5f;
        // PoolFigures
        public const int PoolCountFigures = 100;
        // Ads
        public const float TimeDelayShowAds = 1.5f;
        // Language
        public const string EnglishCode = "en";
        public const string RussianCode = "ru";
        public const string TurkishCode = "tr";
        public const string EnglishLanguage = "English";
        public const string RussianLanguage = "Russian";
        public const string TurkishLanguage = "Turkish";
        // Shop
        public const float ShopCellStep = 325;
        public const int ShopAmountCellsInRow = 3;
    }
}
