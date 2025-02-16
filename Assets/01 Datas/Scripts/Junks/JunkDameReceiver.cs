using UnityEngine;

public class JunkDameReceiver : DamageReceiver
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

        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}
