using UnityEngine;

public class DamageSender : GameMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void SendDamageToObj(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;

        this.SendDamage(damageReceiver);
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
