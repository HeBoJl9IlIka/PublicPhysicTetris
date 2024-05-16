namespace PhysicalTetris.Model
{
    public static class DataTransmitter
    {
        public static Config.GameType GameType { get; private set; }
        public static Config.MapName MapName { get; private set; }
        public static Config.Skin SkinsFigures => Config.Skin.Default;

        //public static int Score => 10;
        //public static int CountFigures => 5;
        //public static int Reward => 15;

        public static void SetGameType(Config.GameType gameType)
        {
            GameType = gameType;
        }

        public static void SetMapName(Config.MapName mapName)
        {
            MapName = mapName;
        }
    }
}
