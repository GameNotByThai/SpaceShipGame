using UnityEngine;

public class HpBarSpawner : Spawner
{
    private static HpBarSpawner instance;
    public static HpBarSpawner Instance => instance;

    private static string hpBar = "HpBar";
    public static string HpBar => hpBar;

    protected override void Awake()
    {
        base.Awake();
        if (HpBarSpawner.instance != null)
        {
            Debug.LogError("Only one HpBarSpawner allow to exist", gameObject);
        }
        HpBarSpawner.instance = this;
    }
}
