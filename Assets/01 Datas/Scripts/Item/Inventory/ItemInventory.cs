using System;
[Serializable]
public class ItemInventory
{
    public ItemProfileSO itemProfileSO;
    public string itemId;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            itemId = ItemInventory.RandomID(10),
            itemProfileSO = this.itemProfileSO,
            itemCount = this.itemCount,
            maxStack = this.itemProfileSO.defaultMaxStack,
            upgradeLevel = this.upgradeLevel
        };

        return item;
    }

    public static string RandomID(int length)
    {
        return RandomStringGenerator.Generate(length);
    }
}
