using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : GameMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected ItemCtrl itemCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTrigger();
    }
    protected virtual void LoadTrigger()
    {
        if (this.sphereCollider != null) return;

        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.1f;
        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);
    }

    public virtual ItemCode GetItemCode()
    {
        return this.String2ItemCode(transform.parent.name);
    }

    protected virtual ItemCode String2ItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }

    public virtual void Picked(Transform obj)
    {
        obj.gameObject.SetActive(false);
    }
}
