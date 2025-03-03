using UnityEngine;

public class ShootableObjDameReceiver : DamageReceiver
{
    [SerializeField] protected ShootableObjectCtrl shootableObjCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.shootableObjCtrl != null) return;

        this.shootableObjCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.shootableObjCtrl.ShootableObjDespawn.DespawnObject();

        this.OnDropDead();
    }

    protected virtual void OnDropDead()
    {
        Vector3 itemPos = transform.position;
        Quaternion itemRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjCtrl.ShootableObjSO.dropList, itemPos, itemRot);
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
        this.hpMax = this.shootableObjCtrl.ShootableObjSO.hpMax;
        base.ReBon();
    }
}
