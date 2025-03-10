using System.Collections.Generic;
using UnityEngine;
public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = false;

    [SerializeField] InventorySort inventorySort;
    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();
        InvokeRepeating(nameof(this.ShowingItem), 1, 1);
    }

    //protected virtual void FixedUpdate()
    //{
    //    this.ShowingItem();
    //}
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.inventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.inventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowingItem()
    {
        if (!this.isOpen) return;
        this.ClearItem();

        List<ItemInventory> items = PlayerCtrl.Instance.CurentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.inventoryCtrl.UIInvItemSpawner;
        //Debug.Log("Item Count: " + itemCount);
        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
        this.SortItem();
    }

    protected virtual void SortItem()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        int itemCount = this.inventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;
        int currentCount, nextCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.inventoryCtrl.Content.GetChild(i);
            nextItem = this.inventoryCtrl.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfileSO;
            nextProfile = nextUIItem.ItemInventory.itemProfileSO;

            bool isSwap = false;
            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    Debug.Log("====== Inventory.SortByName ======");
                    currentName = currentProfile.itemName;
                    nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == 1;
                    Debug.Log(i + ": " + currentName + " | " + nextName + " = " + isSwap);
                    break;
                case InventorySort.ByCount:
                    Debug.Log("====== Inventory.SortByCount ======");
                    currentCount = currentUIItem.ItemInventory.itemCount;
                    nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount < nextCount;
                    Debug.Log(i + ": " + currentCount + " | " + nextCount + " = " + isSwap);
                    break;
            }

            if (isSwap)
            {
                this.SwapItem(currentItem, nextItem);
                isSorting = true;
            }
        }
        if (isSorting) this.SortItem();
    }

    protected virtual void SortByName()
    {

    }

    protected virtual void SwapItem(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

    protected virtual void ClearItem()
    {
        this.inventoryCtrl.UIInvItemSpawner.ClearItem();
    }
}
