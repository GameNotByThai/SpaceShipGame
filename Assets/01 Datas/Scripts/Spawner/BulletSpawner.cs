using UnityEngine;
public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    private static string bulletOne = "Bullet_1";
    public static string BulletOne { get => bulletOne; }

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
        {
            Debug.LogError("Only one BulletSpawner allow to exist", gameObject);
        }
        BulletSpawner.instance = this;
    }
}
