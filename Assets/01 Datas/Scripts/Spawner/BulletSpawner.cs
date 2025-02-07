using UnityEngine;
public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    private static string BulletOne = "Bullet_1";
    public static string BulletOne1 { get => BulletOne; }

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
        {
            Debug.LogError("Only one InputManager allow to exist");
        }
        BulletSpawner.instance = this;
    }
}
