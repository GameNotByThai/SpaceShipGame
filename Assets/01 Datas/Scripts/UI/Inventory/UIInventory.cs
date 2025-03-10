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
        switch (this.inventorySort)
        {
            case InventorySort.ByName:
                Debug.Log("Sort By Name");
                break;
            case InventorySort.ByCount:
                Debug.Log("Sort By Count");
                break;
            case InventorySort.ById:
                Debug.Log("Sort By Id");
                break;
            default:
                Debug.Log("No Sort");
                break;
        }
    }

    protected virtual void ClearItem()
    {
        this.inventoryCtrl.UIInvItemSpawner.ClearItem();
    }
}
