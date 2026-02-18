using MessagePack;

[MessagePackObject]
public class ItemSaveData
{
    [Key(0)] public Slot itemSlot;
    [Key(1)] public string itemName;

    [Key(2)] public int itemDamage;
    [Key(3)] public int itemArmor;
}
