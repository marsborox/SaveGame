using UnityEngine;
using System.IO;//we use this if we want to communicate with files on system
using MessagePack;

// he used public static class GameSaveLoad
public class SaveLoadSystem : Singleton<SaveLoadSystem>
{
    public static new SaveLoadSystem instance => Singleton<SaveLoadSystem>.instance;

    public string fileName = "/saveHeroObject.fun";
    public string savePath;

    private void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        savePath = Application.persistentDataPath + fileName;
    }
    //he used public static void SaveObject
    public void SaveHero(HeroSaveData data)
    {
        byte[] bytes = MessagePackSerializer.Serialize(data);
        File.WriteAllBytes(savePath, bytes);
    }
    //he used public static GameSaveData
    public HeroSaveData LoadHero()
    {
        
        if (File.Exists(savePath))
        {
            byte[] bytes = File.ReadAllBytes(savePath);
            HeroSaveData data = MessagePackSerializer.Deserialize<HeroSaveData>(bytes);

            return data;
        }
        else
        {
            Debug.Log("SaveFile not found in" + savePath);
            return null;
        }
    }
    public void SaveAllHeroes()
    {
        GameSaveData data = new GameSaveData();
        foreach (Hero hero in HeroManager.instance.heroList)
        {
            HeroSaveData heroData = hero.SaveHero();
            data.heroSaveList.Add(heroData);
        }
        byte[] bytes = MessagePackSerializer.Serialize(data);
        File.WriteAllBytes(savePath, bytes);
    }
    public void LoadAllHeroes()
    {
        GameSaveData data = new GameSaveData();

        if (File.Exists(savePath))
        {
            byte[] bytes = File.ReadAllBytes(savePath);
            data = MessagePackSerializer.Deserialize<GameSaveData>(bytes);
        }
        else
        {
            Debug.Log("SaveFile not found in" + savePath);
            
        }
        foreach (HeroSaveData heroData in data.heroSaveList)
        { 
            HeroManager.instance.SpawnHeroFromLoad(heroData);
        }
    }

}