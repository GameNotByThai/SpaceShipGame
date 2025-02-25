using UnityEngine;

public class PlayerPickup : PlayerAbtract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("Item Picked");

        //ItemCode itemCode = itemPickupable.GetItemCode();

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.playerCtrl.CurentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
