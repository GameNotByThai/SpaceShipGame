public class ItemDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }
}
