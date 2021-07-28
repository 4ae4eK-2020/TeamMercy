namespace Structs
{
    [System.Serializable]
    public struct JsonStruct
    {
        public int HeroID;
        public HeroParamsStruct selectedHero;
    }

    [System.Serializable]
    public struct PlayerStruct
    {
        public playerInfo player;
    }
}