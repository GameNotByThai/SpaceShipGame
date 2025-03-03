using UnityEngine;

public abstract class AbilityObjectCtrl : ShootableObjectCtrl
{
    [Header("Ability Object")]
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => spawnPoint;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;

        this.spawnPoint = transform.GetComponentInChildren<SpawnPoint>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoint", gameObject);
    }
}
