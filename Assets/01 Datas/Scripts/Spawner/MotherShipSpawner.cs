using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null)
        {
            Debug.LogError("Only one MotherShipSpawner allow to exist", gameObject);
        }
        MotherShipSpawner.instance = this;
    }
}
