using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamageReceiver : GameMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hpCurrent = 2;
    [SerializeField] protected int hpMax = 2;
    [SerializeField] protected bool isDead = false;
    //protected override void Start()
    //{
    //    this.ReBon();
    //}

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ReBon();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;

        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void ReBon()
    {
        this.hpCurrent = this.hpMax;
        this.isDead = false;
    }

    public virtual void AddHp(int add)
    {
        if (this.isDead) return;

        this.hpCurrent += add;
        if (this.hpCurrent > hpMax) this.hpCurrent = this.hpMax;
    }

    public virtual void DeductHp(int deduct)
    {
        if (this.isDead) return;

        this.hpCurrent -= deduct;
        if (this.hpCurrent < 0) this.hpCurrent = 0;

        this.CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        //For override
    }

    protected virtual bool IsDead()
    {
        return this.hpCurrent <= 0;
    }
}
