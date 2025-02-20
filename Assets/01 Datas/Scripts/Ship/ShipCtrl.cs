using UnityEngine;

public class ShipCtrl : GameMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;

        this.inventory = GetComponentInChildren<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
    }
}
