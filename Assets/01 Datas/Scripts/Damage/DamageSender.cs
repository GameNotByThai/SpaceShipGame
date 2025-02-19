using UnityEngine;

public class DamageSender : GameMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void SendDamageToObj(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;

        this.SendDamage(damageReceiver);
        this.CreateImpactFX();
    }
    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactName();

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactName()
    {
        return FXSpawner.Impact_1;
    }

    protected virtual void SendDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(this.damage);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
