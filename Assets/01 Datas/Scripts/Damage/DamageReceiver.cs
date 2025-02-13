using UnityEngine;

public class DamageReceiver : GameMonoBehaviour
{
    [SerializeField] protected int hpCurrent = 2;
    [SerializeField] protected int hpMax = 2;

    protected override void Start()
    {
        this.ReBon();
    }

    protected virtual void ReBon()
    {
        this.hpCurrent = this.hpMax;
    }

    public virtual void AddHp(int add)
    {
        this.hpCurrent += add;
        if (this.hpCurrent > hpMax) this.hpCurrent = this.hpMax;
    }

    public virtual void DeductHp(int deduct)
    {
        this.hpCurrent -= deduct;
        if (this.hpCurrent < 0) this.hpCurrent = 0;
    }

    protected virtual bool IsDead()
    {
        return this.hpCurrent < 0;
    }
}
