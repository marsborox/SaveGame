using UnityEngine;

public class Hero : MonoBehaviour
{
    public string heroName = "Johnny";
    public int level = 5;
    public int health = 10;

    private void Start()
    {
        //GameSaveLoadSystem.instance.SaveObject(this);
    }

    #region originalMethods
    public void SaveThisHero()
    {
        // he would use SaveSystem.SaveObject(this);

        HeroSaveData data = new HeroSaveData();
        data.heroName = heroName;
        data.level = level;
        data.health = health;
        data.position = transform.position;

        SaveLoadSystem.instance.SaveHero(data);
    }
    public void LoadHero()
    {
        HeroSaveData data = SaveLoadSystem.instance.LoadHero();
        heroName = data.heroName;
        level = data.level;
        health = data.health;
        
        transform.position = data.position;
        Debug.Log("Load Finished");
        
    }
    #endregion
    public HeroSaveData SaveHero()
    {
        // he would use SaveSystem.SaveObject(this);

        HeroSaveData data = new HeroSaveData();
        data.heroName = heroName;
        data.level = level;
        data.health = health;
        data.position = transform.position;

        //SaveLoadSystem.instance.SaveHero(data);
        return data;
    }
    public void LoadHero(HeroSaveData saveData)
    {
        //HeroSaveData data = SaveLoadSystem.instance.LoadHero();
        heroName = saveData.heroName;
        level = saveData.level;
        health = saveData.health;


        transform.position = saveData.position;
        Debug.Log("Load Finished");

    }
}
