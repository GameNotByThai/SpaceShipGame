using System.Collections.Generic;
using UnityEngine;

public class Inventory : GameMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.IronOre, 21);
        this.AddItem(ItemCode.CopperSword, 3);
    }

    //public virtual bool AddItem(ItemCode itemCode, int addCount)
    //{
    //    ItemProfileSO itemProfileSO = this.GetItemProfile(itemCode);
    //    if (itemProfileSO == null) Debug.LogWarning("Can not found ItemProfile which have this ItemCode");

    //    ItemInventory itemExist = this.GetItemNoFullStack(itemCode);
    //    if (itemExist == null)
    //    {
    //        if (this.IsFullInventorySlot()) return false;

    //        itemExist = this.CreateNewSlotInventory(itemProfileSO);
    //        this.items.Add(itemExist);
    //    }

    //    if (itemExist.itemCount + addCount <= itemExist.maxStack)
    //    {
    //        itemExist.itemCount += addCount;
    //        return true;
    //    }

    //    int stackAddFull = 
    //}

    protected virtual ItemInventory CreateNewSlotInventory(ItemProfileSO itemProfile)
    {
        ItemInventory newItem = new ItemInventory
        {
            itemProfileSO = itemProfile,
            maxStack = itemProfile.defaultMaxStack,
        };
        return newItem;
    }

    protected virtual bool IsFullInventorySlot()
    {
        return this.items.Count >= maxSlot;
    }

    protected virtual ItemInventory GetItemNoFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory item in this.items)
        {
            if (item.itemProfileSO.itemCode != itemCode) continue;
            if (item.itemCount == item.maxStack) continue;
            return item;
        }
        return null;
    }

    private ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll<ItemProfileSO>("Item");
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
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
        var profiles = Resources.LoadAll<ItemProfileSO>("Item");
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
