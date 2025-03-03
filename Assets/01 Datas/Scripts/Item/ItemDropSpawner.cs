using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner _instance;
    public static ItemDropSpawner Instance { get => _instance; }
    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner._instance != null)
        {
            Debug.LogError("Only one DropManager allow to exist", gameObject);
        }
        ItemDropSpawner._instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 itemPos, Quaternion itemRot)
    {
        //Todo
        if (dropList.Count < 1) return;

        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), itemPos, itemRot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 itemPos, Quaternion itemRot)
    {
        ItemCode itemCode = itemInventory.itemProfileSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), itemPos, itemRot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);
        return itemDrop;
    }
}
