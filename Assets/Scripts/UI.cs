using System;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{

    public Button saveHeroButton;
    public Button loadHeroButton;
    public Button spawn5Randoms;
    public Button destroyAll;
    public Button saveAll;
    public Button loadAll;

    public Hero hero;
    private void Start()
    {
        //InitiateButton(saveHeroButton, hero.SaveThisHero);
        //InitiateButton(loadHeroButton,hero.LoadHero);
        InitiateButton(spawn5Randoms, ObjectManager.instance.Spawn5Randoms);
        InitiateButton(destroyAll, ObjectManager.instance.DestoryAll);
        InitiateButton(saveAll, SaveLoadSystem.instance.SaveAll);
        InitiateButton(loadAll, SaveLoadSystem.instance.LoadAll);
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
