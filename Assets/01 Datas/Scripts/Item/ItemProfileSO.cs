using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemTpye = ItemType.NoType;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public List<ItemRecipe> upgrageLevels;
}
