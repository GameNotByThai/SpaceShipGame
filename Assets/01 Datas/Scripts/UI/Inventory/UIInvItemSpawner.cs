using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;

    private static string normalItem = "UIInvItem";
    public static string NormalItem => normalItem;

    [Header("Inv Item Spawner")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIInvItemSpawner.instance != null)
        {
            Debug.LogError("Only one UIInvItemSpawner allow to exist", gameObject);
        }
        UIInvItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtrl();
        if (this.holder != null) return;
        this.holder = this.inventoryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }

    public virtual void ClearItem()
    {
        foreach (Transform item in holder)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.Spawn(UIInvItemSpawner.NormalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = Vector3.one;

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}
