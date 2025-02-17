using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : GameMonoBehaviour
{
    [SerializeField] protected Transform holder;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    private void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabsObj = this.transform.Find("Prefabs");

        foreach (Transform prefab in prefabsObj)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();

        Debug.Log(transform.name + ": LoadComponent", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Can't find prefab: " + prefabName);
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj == null || Object.ReferenceEquals(poolObj, null))
            {
                Debug.Log("Have bug object");
                poolObjs.Remove(poolObj);
                continue;
            }
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }

    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
