using UnityEngine;

public class SpawnerCtrl : GameMonoBehaviour
{
    [SerializeField] protected Spawner spawner;

    [SerializeField] protected SpawnPoint spawnPoint;

    public Spawner Spawner => spawner;
    public SpawnPoint SpawnPoint => spawnPoint;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;

        this.spawner = GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;

        this.spawnPoint = Transform.FindObjectOfType<SpawnPoint>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoint", gameObject);
    }
}
