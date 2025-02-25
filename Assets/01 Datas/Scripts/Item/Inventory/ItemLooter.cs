using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : InventoryAbstract
{
    [Header("Item Looter")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
        this.LoadTrigger();
        this.LoadRigidbody();
    }
    protected virtual void LoadTrigger()
    {
        if (this.sphereCollider != null) return;

        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.3f;
        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;

        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
