using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObjectSO", menuName = "SO/ShootableObjectSO")]
public class ShootableObjectSO : ScriptableObject
{
    public string objName = "no-name";
    public ObjectType objectType = ObjectType.NoType;
    public int hpMax = 2;
    public List<ItemDropRate> dropList;
}