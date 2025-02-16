using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;

        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + "LoadBulletCtrl", gameObject);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        base.SendDamage(damageReceiver);

    }

    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
