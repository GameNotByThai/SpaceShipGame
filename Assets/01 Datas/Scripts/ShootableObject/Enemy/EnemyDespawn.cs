public class EnemyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        this.disLimit = 50f;
    }
}
