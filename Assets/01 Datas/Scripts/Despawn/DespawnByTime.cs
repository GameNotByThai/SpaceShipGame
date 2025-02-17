using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float despawnTimer = 0f;
    [SerializeField] protected float despawnDelay = 2f;
    protected override bool CanDespawn()
    {
        despawnTimer += Time.fixedDeltaTime;
        if (despawnTimer > despawnDelay) return true;
        return false;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }

    protected virtual void ResetTimer()
    {
        this.despawnTimer = 0f;
    }
}
