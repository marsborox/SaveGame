using System;
using System.Collections.Generic;

using UnityEngine;


public class HeroManager : Singleton<HeroManager>
{
    public static new HeroManager instance => Singleton<HeroManager>.instance;

    public List<Hero> heroList = new List<Hero>();

    public Hero heroPrefab;

    string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789"; //add the characters you want
    private void Awake()
    {
        base.Awake();
    }
    public void Spawn5Heros()
    {
        for (int i = 0; i < 5; i++)
        { 
            SpawnRandomHero();
        }
    }
    public void DestoryAllHeroes()
    {
        if (heroList.Count > 0) 
        {
            Hero hero = heroList[0];
            heroList.RemoveAt(0);
            Destroy(hero.gameObject);
            DestoryAllHeroes();
        }
    }

    void SpawnRandomHero()
    {
        Hero hero = Instantiate(heroPrefab);
        heroList.Add(hero);

        hero.heroName = RandomName();
        hero.name = hero.heroName;
        hero.health = UnityEngine.Random.Range(0,100);
        hero.level = hero.health = UnityEngine.Random.Range(0, 100);
        hero.transform.SetParent(transform);
    }
    public void SpawnHeroFromLoad(HeroSaveData saveData)
    {
        Hero hero = Instantiate(heroPrefab);
        heroList.Add(hero);
        SetHeroStats(hero, saveData);
        hero.transform.SetParent(transform);
    }
    public void SetHeroStats(Hero hero, HeroSaveData saveData)
    {
        hero.name = saveData.heroName;
        hero.health = saveData.health;
        hero.level = saveData.level;
    }
    string RandomName()
    {
        string myString = "";
        int charAmount = 5; //set those to the minimum and maximum length of your string
        for (int i = 0; i < charAmount; i++)
        {
            myString += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
        }
        return myString;
    }

}
