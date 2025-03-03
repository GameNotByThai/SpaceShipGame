using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Base Ability")]
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        this.Summon();
    }

    protected virtual Transform Summon()
    {
        Transform spawnPos = this.abilities.AbilityObjectCtrl.SpawnPoint.GetRandom();

        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, spawnPos.position, spawnPos.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
        return minion;
    }
}
