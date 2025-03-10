using UnityEngine;
public abstract class UIInventoryAbstract : GameMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl InventoryCtrl => inventoryCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.UIInventoryCtrl();
    }
    protected virtual void UIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": UIInventoryCtrl", gameObject);
    }
}
