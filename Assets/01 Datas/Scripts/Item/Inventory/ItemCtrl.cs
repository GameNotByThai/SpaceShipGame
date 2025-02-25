using UnityEngine;

public class ItemCtrl : GameMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;

        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.LogWarning(transform.name + ": LoadItemDespawn", gameObject);
    }
    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfileSO != null) return;

        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfileSO = itemProfile;
        this.ResetItem();
        this.itemInventory.maxStack = itemProfile.defaultMaxStack;
        Debug.Log(transform.name + ": LoadItemInventory", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }

}
