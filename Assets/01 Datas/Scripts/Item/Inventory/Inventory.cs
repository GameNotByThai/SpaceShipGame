using System.Collections.Generic;
using UnityEngine;

public class Inventory : GameMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    public int MaxSlot => maxSlot;

    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.CopperSword, 1);
        this.AddItem(ItemCode.GoldOre, 10);
        this.AddItem(ItemCode.CopperSword, 1);
        this.AddItem(ItemCode.IronOre, 20);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfileSO = ItemProfileSO.FindByItemCode(itemCode);
        if (itemProfileSO == null) Debug.LogWarning("Can not found ItemProfile which have this ItemCode");

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNoFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsFullInventorySlot()) return false;

                itemExist = this.CreateNewSlotInventory(itemProfileSO);
                this.items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;
            itemMaxStack = this.GetItemMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }

        return true;
    }

    protected virtual int GetItemMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;

        return itemInventory.maxStack;
    }

    protected virtual ItemInventory CreateNewSlotInventory(ItemProfileSO itemProfile)
    {
        ItemInventory newItem = new ItemInventory
        {
            itemId = ItemInventory.RandomID(10),
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

    //protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    //{
    //    var profiles = Resources.LoadAll<ItemProfileSO>("Item");
    //    foreach (ItemProfileSO profile in profiles)
    //    {
    //        if (profile.itemCode != itemCode) continue;
    //        return profile;
    //    }
    //    return null;
    //}

    public virtual bool ItemCheck(ItemCode itemCode, int itemCount)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= itemCount;
    }

    protected virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.itemProfileSO.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }
        return totalCount;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];
            if (itemInventory.itemProfileSO.itemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }

        this.ClearEmptySlot();
    }

    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for (int i = 0; i < this.items.Count; i++)
        {
            itemInventory = this.items[i];
            if (itemInventory.itemCount == 0) this.items.RemoveAt(i);
        }
    }
























    //public virtual bool AddItem(ItemCode itemCode, int addCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //    if (itemInventory == null) return false;
    //    int newCount = itemInventory.itemCount + addCount;
    //    if (newCount > itemInventory.maxStack) return false;

    //    itemInventory.itemCount = newCount;
    //    return true;
    //}

    //public virtual bool DeductItem(ItemCode itemCode, int deductCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //    if (itemInventory == null) return false;
    //    int newCount = itemInventory.itemCount - deductCount;
    //    if (newCount < 0) return false;

    //    itemInventory.itemCount = newCount;
    //    return true;
    //}

    //public virtual bool TryDeductItem(ItemCode itemCode, int deductCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //    if (itemInventory == null) return false;
    //    int newCount = itemInventory.itemCount - deductCount;
    //    if (newCount < 0) return false;

    //    return true;
    //}

    //private ItemInventory GetItemByCode(ItemCode itemCode)
    //{
    //    ItemInventory itemInventory = items.Find((item) => item.itemProfileSO.itemCode == itemCode);
    //    if (itemInventory == null) return itemInventory = this.AddEmtyProfile(itemCode);
    //    if (itemInventory == null) return null;
    //    return itemInventory;
    //}

    //private ItemInventory AddEmtyProfile(ItemCode itemCode)
    //{
    //    var profiles = Resources.LoadAll<ItemProfileSO>("Item");
    //    foreach (ItemProfileSO profile in profiles)
    //    {
    //        if (profile.itemCode != itemCode) continue;
    //        ItemInventory itemInventory = new ItemInventory
    //        {
    //            itemProfileSO = profile,
    //            maxStack = profile.defaultMaxStack
    //        };
    //        this.items.Add(itemInventory);
    //        return itemInventory;
    //    }
    //    return null;
    //}
}
