public class JunkDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        this.disLimit = 15f;
    }
}
