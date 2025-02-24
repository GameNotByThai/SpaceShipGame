using UnityEngine;

public class ItemCtrl : GameMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;

        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.LogWarning(transform.name + ": LoadItemDespawn", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
}
