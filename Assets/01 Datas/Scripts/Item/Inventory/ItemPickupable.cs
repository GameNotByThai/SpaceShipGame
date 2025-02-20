using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
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
        this.sphereCollider.radius = 0.2f;
        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);
    }

    public virtual void OnMouseDown()
    {
        Debug.Log(transform.parent.name);
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }

    public virtual ItemCode GetItemCode()
    {
        try
        {
            return this.String2ItemCode(transform.parent.name);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }

    protected virtual ItemCode String2ItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }

    public virtual void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObject();
    }
}
