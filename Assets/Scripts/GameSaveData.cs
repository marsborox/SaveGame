using System.Collections.Generic;
using MessagePack;

//[System.Serializable]//means we can save it in file
[MessagePackObject]
public class GameSaveData
{
    [Key(0)] public List<HeroSaveData> heroSaveList = new List<HeroSaveData>();

    
    [Key(1)] public readonly int level;
    [Key(2)] public readonly int health;
    [Key(3)] public readonly float[] position;


   
}
