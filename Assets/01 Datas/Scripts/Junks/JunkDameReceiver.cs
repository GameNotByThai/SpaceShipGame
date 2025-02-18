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
        this.OnDeadFX();
        this.junkCtrl.JunkDespawn.DespawnObject();

        this.OnDropDead();
    }

    protected virtual void OnDropDead()
    {
        Vector3 itemPos = transform.position;
        Quaternion itemRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.JunkSO.dropList, itemPos, itemRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.Smoke1;
    }

    protected override void ReBon()
    {
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        base.ReBon();
    }
}
