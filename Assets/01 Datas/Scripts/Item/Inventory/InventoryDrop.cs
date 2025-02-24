using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 7);
    }

    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }

    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        Debug.Log(itemInventory.itemProfileSO.itemCode);
        Debug.Log(itemInventory.upgradeLevel);

        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, dropRot);
        this.inventory.Items.Remove(itemInventory);
    }
}
