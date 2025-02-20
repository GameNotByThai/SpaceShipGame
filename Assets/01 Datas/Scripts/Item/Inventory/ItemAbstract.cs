using UnityEngine;

public class ItemAbstract : GameMonoBehaviour
{
    [Header("Item Abstract")]
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;

        this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
        Debug.LogWarning(transform.name + ": LoadItemCtrl", gameObject);
    }
}
