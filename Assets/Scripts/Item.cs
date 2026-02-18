using UnityEngine;

public enum Slot { HEAD, CHEST, WEAPON,BROKEN}
public class Item : MonoBehaviour
{
    public Slot itemSlot;
    public string itemName;

    public int itemDamage;
    public int itemArmor;

    public ItemSaveData SaveItem()
    { 
        ItemSaveData data = new ItemSaveData();
        data.itemSlot = itemSlot;
        data.itemName = itemName;
        data.itemDamage = itemDamage;
        data.itemArmor = itemArmor;
        return data;
    }
    public void LoadItem(ItemSaveData saveData)
    { 
        itemSlot = saveData.itemSlot;
        itemName = saveData.itemName;
        name = saveData.itemName;
        itemDamage = saveData.itemDamage;
        itemArmor = saveData.itemArmor;

    }
}
