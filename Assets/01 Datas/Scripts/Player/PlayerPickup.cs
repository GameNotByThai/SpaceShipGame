using UnityEngine;

public class PlayerPickup : PlayerAbtract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("Item Picked");

        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.playerCtrl.CurentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
