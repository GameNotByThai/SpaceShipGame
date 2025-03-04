using System;
using System.Collections.Generic;
using UnityEngine;
public class ItemDropTest : GameMonoBehaviour
{
    public JunkCtrl junkCtrl;
    public int dropCount = 0;
    public List<ItemDropCount> dropCountItems = new List<ItemDropCount>();
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Dropping), 2f, 0.2f);
    }

    protected virtual void Dropping()
    {
        this.dropCount++;
        Vector3 itemPos = transform.position;
        Quaternion itemRot = transform.rotation;
        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkCtrl.JunkSO.dropList, itemPos, itemRot);

        ItemDropCount itemDrop;
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            itemDrop = this.dropCountItems.Find(i => i.itemName == itemDropRate.itemSO.name);
            if (itemDrop == null)
            {
                itemDrop = new ItemDropCount();
                itemDrop.itemName = itemDropRate.itemSO.name;
                dropCountItems.Add(itemDrop);
            }

            itemDrop.count += 1;
            itemDrop.rate = (float)Math.Round((float)itemDrop.count / this.dropCount, 2);
        }
    }

}

[Serializable]
public class ItemDropCount
{
    public string itemName;
    public int count;
    public float rate;
}
