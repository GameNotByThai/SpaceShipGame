using System.Collections.Generic;
using UnityEngine;

public class Inventory : GameMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        //this.AddItem(ItemCode.IronOre, 3);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        if (itemInventory == null) return false;
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        if (itemInventory == null) return false;
        int newCount = itemInventory.itemCount - deductCount;
        if (newCount < 0) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool TryDeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        if (itemInventory == null) return false;
        int newCount = itemInventory.itemCount - deductCount;
        if (newCount < 0) return false;

        return true;
    }

    private ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = items.Find((item) => item.itemProfileSO.itemCode == itemCode);
        if (itemInventory == null) return itemInventory = this.AddEmtyProfile(itemCode);
        if (itemInventory == null) return null;
        return itemInventory;
    }

    private ItemInventory AddEmtyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll<ItemProfileSO>("ItemProfiles");
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfileSO = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
