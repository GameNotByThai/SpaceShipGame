using UnityEngine;

public class JunkSpawnerRandom : GameMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected int randomLimit = 9;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;

        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    //protected override void Start()
    //{
    //    this.JunkSpawning();
    //}

    protected virtual void FixedUpdate()
    {
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;

        Transform ranPoint = this.junkSpawnerCtrl.JunkSpawnPoint.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform spawnPos = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        spawnPos.gameObject.SetActive(true);

        //Invoke(nameof(JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= randomLimit;
    }
}
