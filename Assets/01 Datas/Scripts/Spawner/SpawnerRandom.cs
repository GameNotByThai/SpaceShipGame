using UnityEngine;

public class SpawnerRandom : GameMonoBehaviour
{
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected int randomLimit = 9;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnerCtrl();
    }

    protected virtual void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;

        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        Spawning();
    }

    protected virtual void Spawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;

        Transform ranPoint = this.spawnerCtrl.SpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = spawnerCtrl.Spawner.RandomPrefab();
        Transform spawnPos = this.spawnerCtrl.Spawner.Spawn(prefab, pos, rot);
        spawnPos.gameObject.SetActive(true);

        //Invoke(nameof(JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = spawnerCtrl.Spawner.SpawnedCount;
        return currentJunk >= randomLimit;
    }
}
