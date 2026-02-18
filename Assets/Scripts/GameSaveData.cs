using System.Collections.Generic;
using MessagePack;

//[System.Serializable]//means we can save it in file
[MessagePackObject]
public class GameSaveData
{
    [Key(0)] public List<HeroSaveData> heroSaveList = new List<HeroSaveData>();
    [Key(1)] public List<ItemSaveData> itemSaveList = new List<ItemSaveData>();
}
