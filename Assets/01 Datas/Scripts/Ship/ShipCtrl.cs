using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    [Header("Ship")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override string GetSONameToString()
    {
        return ObjectType.Ship.ToString();
    }

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
