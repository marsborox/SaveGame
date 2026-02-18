using MessagePack;
using UnityEngine;
[MessagePackObject]
public class HeroSaveData
{
    [Key(0)] public  string heroName;
    [Key(1)] public int level;
    [Key(2)] public int health;
    [Key(3)] public Vector3 position;

    [Key(4)] public string itemName;

    [SerializationConstructor]
    public HeroSaveData()
    { }
    public HeroSaveData(string inputHeroName,int inputHeroLevel,int inputHeroHealth, Vector3 inputPosition)
    {
        heroName = inputHeroName;
        level = inputHeroLevel;
        health = inputHeroHealth;

        position = inputPosition;
    }
}
