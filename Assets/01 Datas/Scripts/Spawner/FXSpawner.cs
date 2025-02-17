using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance => instance;

    private static string smoke1 = "Smoke_1";
    public static string Smoke1 => smoke1;

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null)
        {
            Debug.LogError("Only one BulletSpawner allow to exist", gameObject);
        }
        FXSpawner.instance = this;
    }
}
