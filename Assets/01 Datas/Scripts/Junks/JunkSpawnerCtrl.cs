using UnityEngine;

public class JunkSpawnerCtrl : GameMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;

    [SerializeField] protected JunkSpawnPoint junkSpawnPoint;

    public JunkSpawner JunkSpawner { get => junkSpawner; }
    public JunkSpawnPoint JunkSpawnPoint { get => junkSpawnPoint; }

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
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadJunkSpawnPoint()
    {
        if (this.junkSpawnPoint != null) return;

        this.junkSpawnPoint = Transform.FindObjectOfType<JunkSpawnPoint>();
        Debug.Log(transform.name + ": LoadJunkSpawnPoint", gameObject);
    }
}
