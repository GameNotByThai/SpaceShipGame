using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null)
        {
            Debug.LogError("Only one EnemySpawner allow to exist", gameObject);
        }
        EnemySpawner.instance = this;
    }
}
