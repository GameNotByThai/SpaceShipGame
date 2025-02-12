using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }

    private static string meteoriteOne = "Meteorite_1";
    public static string MeteoriteOne { get => meteoriteOne; }

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null)
        {
            Debug.LogError("Only one JunkSpawner allow to exist", gameObject);
        }
        JunkSpawner.instance = this;
    }
}
