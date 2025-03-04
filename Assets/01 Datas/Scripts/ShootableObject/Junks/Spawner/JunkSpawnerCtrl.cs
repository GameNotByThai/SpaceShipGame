using UnityEngine;

public class JunkSpawnerCtrl : GameMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;

    [SerializeField] protected SpawnPoint junkSpawnPoint;

    public JunkSpawner JunkSpawner { get => junkSpawner; }
    public SpawnPoint JunkSpawnPoint { get => junkSpawnPoint; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoint();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;

        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.LogWarning(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadJunkSpawnPoint()
    {
        if (this.junkSpawnPoint != null) return;

        this.junkSpawnPoint = GameObject.Find("GameSpawnPoint").GetComponent<SpawnPoint>();
        Debug.LogWarning(transform.name + ": LoadJunkSpawnPoint", gameObject);
    }
}
