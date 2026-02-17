using System;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{

    public Button saveHeroButton;
    public Button loadHeroButton;
    public Button spawn5Heros;
    public Button destroyAllHeros;
    public Button saveAllHeros;
    public Button loadAllHeros;

    public Hero hero;
    private void Start()
    {
        InitiateButton(saveHeroButton, hero.SaveThisHero);
        InitiateButton(loadHeroButton,hero.LoadHero);
        InitiateButton(spawn5Heros, HeroManager.instance.Spawn5Heros);
        InitiateButton(destroyAllHeros, HeroManager.instance.DestoryAllHeroes);
        InitiateButton(saveAllHeros, SaveLoadSystem.instance.SaveAllHeroes);
        InitiateButton(loadAllHeros, SaveLoadSystem.instance.LoadAllHeroes);
    }

    public void InitiateButton(Button button, Action method)
    {
        button.onClick.AddListener(delegate
        {
            method();
        });
        //boolUI = false;
    }
    public void InitiateButton<T>(Button button, Action<T> method, T value)
    {
        button.onClick.AddListener(delegate
        {
            method(value);
        });
        //boolUI = false;
    }
    void Asdf()
    { }
}
