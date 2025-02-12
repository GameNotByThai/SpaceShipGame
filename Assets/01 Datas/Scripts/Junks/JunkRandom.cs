using UnityEngine;

public class JunkRandom : GameMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;

        this.junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform spawnPos = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.MeteoriteOne, pos, rot);
        spawnPos.gameObject.SetActive(true);

        Invoke(nameof(JunkSpawning), 1f);
    }
}
