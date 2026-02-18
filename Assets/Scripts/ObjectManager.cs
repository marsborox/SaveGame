using System.Collections.Generic;
public class ObjectManager : Singleton<ObjectManager>
{
    public static new ObjectManager instance => Singleton<ObjectManager>.instance;

    public List<Hero> heroList = new List<Hero>();
    public List<Item> itemList = new List<Item>();

    public Hero heroPrefab;
    public Item itemPrefab;
    string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789"; //add the characters you want
    private void Awake()
    {
        base.Awake();
    }
    public void Spawn5Randoms()
    {
        for (int i = 0; i < 5; i++)
        {
            //SpawnRandomHero();
            //SpawnRandomItem();
            SpawnRandomHeroWithItem();
        }
    }
    #region Destroy
    public void DestoryAll()
    { 
        DestoryAllHeroes();
        DestoryAllItems();
    }
    void DestoryAllHeroes()
    {
        if (heroList.Count > 0) 
        {
            Hero hero = heroList[0];
            heroList.RemoveAt(0);
            Destroy(hero.gameObject);
            DestoryAllHeroes();
        }
    }
    void DestoryAllItems()
    {
        if (itemList.Count > 0)
        {
            Item item = itemList[0];
            itemList.RemoveAt(0);
            Destroy(item.gameObject);
            DestoryAllItems();
        }
    }
    #endregion
    #region Heroes

    void SpawnRandomHero()
    {
        Hero hero = Instantiate(heroPrefab);
        heroList.Add(hero);

        hero.heroName = RandomName();
        hero.name = hero.heroName;
        hero.health = UnityEngine.Random.Range(0,100);
        hero.level  = UnityEngine.Random.Range(0,100);
        hero.transform.SetParent(transform);
    }
    void SpawnRandomHeroWithItem()
    {
        Hero hero = Instantiate(heroPrefab);
        heroList.Add(hero);

        hero.heroName = RandomName();
        hero.name = hero.heroName;
        hero.health = UnityEngine.Random.Range(0, 100);
        hero.level = UnityEngine.Random.Range(0, 100);
        hero.transform.SetParent(transform);
        hero.DressItem(ReturnRandomItem());
    }

    public void SpawnHeroFromLoad(HeroSaveData saveData)
    {
        Hero hero = Instantiate(heroPrefab);
        heroList.Add(hero);
        hero.LoadHero(saveData);
        hero.transform.SetParent(transform);
    }
    public void SetHeroStats(Hero hero, HeroSaveData saveData)
    {
        hero.name = saveData.heroName;
        hero.heroName = saveData.heroName;
        hero.health = saveData.health;
        hero.level = saveData.level;
    }
    #endregion
    #region Items
    void SpawnRandomItem()
    { 
        Item item = Instantiate(itemPrefab);
        itemList.Add(item);

        item.itemName = RandomName();
        item.name = item.itemName;
        item.itemDamage = UnityEngine.Random.Range(0, 100);
        item.itemArmor = UnityEngine.Random.Range(0, 100);
        item.itemSlot = RandomSlot();
        item.transform.SetParent(transform);
    }
    Item ReturnRandomItem()
    {
        Item item = Instantiate(itemPrefab);
        itemList.Add(item);

        item.itemName = RandomName();
        item.name = item.itemName;
        item.itemDamage = UnityEngine.Random.Range(0, 100);
        item.itemArmor = UnityEngine.Random.Range(0, 100);
        item.itemSlot = RandomSlot();
        item.transform.SetParent(transform);
        return item;

    }

    public void SpawnItemFromLoad(ItemSaveData saveData)
    {
        Item item = Instantiate(itemPrefab);
        itemList.Add(item);
        item.LoadItem(saveData);
        item.transform.SetParent(transform);
    }

    #endregion
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
    Slot RandomSlot()
    {
        int index = UnityEngine.Random.Range(0, 2);

        Slot slot;

        switch (index)
        {
            case 0:
                {
                    slot = Slot.HEAD;
                    break;
                }
            case 1:
                {
                    slot = Slot.CHEST;
                    break;
                }
            case 2:
                {
                    slot = Slot.WEAPON;
                    break;
                }
            default:
                {
                    slot = Slot.BROKEN;
                    break;
                }
        }
        return slot;
    }
}
