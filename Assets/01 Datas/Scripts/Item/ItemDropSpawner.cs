using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner _instance;
    public static ItemDropSpawner Instance { get => _instance; }

    [SerializeField] protected float gameDropRate = 1f;
    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner._instance != null)
        {
            Debug.LogError("Only one DropManager allow to exist", gameObject);
        }
        ItemDropSpawner._instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 itemPos, Quaternion itemRot)
    {
        List<ItemDropRate> dropItem = new List<ItemDropRate>();
        if (dropList.Count < 1) return dropItem;

        dropItem = this.DropItem(dropList);
        foreach (ItemDropRate item in dropItem)
        {
            ItemCode itemCode = item.itemSO.itemCode;
            Transform itemDrop = this.Spawn(itemCode.ToString(), itemPos, itemRot);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }

        return dropItem;
    }

    protected virtual List<ItemDropRate> DropItem(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        float rate, itemRate;
        int itemDropMore;
        foreach (ItemDropRate item in items)
        {
            rate = (Random.Range(0, 1f));
            itemRate = item.dropRate / 100000f * this.GameDropRate();
            itemDropMore = Mathf.FloorToInt(itemRate);
            //Debug.Log("=========================");
            //Debug.Log("item:" + item.itemSO.name);
            //Debug.Log("rate:" + rate);
            //Debug.Log("itemRate:" + itemRate);
            //Debug.Log("itemDropMore:" + itemDropMore);

            if (itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++)
                {
                    droppedItems.Add(item);
                }
            }

            if (rate <= itemRate)
            {
                //Debug.Log("DROPED");
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    protected virtual float GameDropRate()
    {
        return this.gameDropRate;
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 itemPos, Quaternion itemRot)
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
