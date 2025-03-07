using UnityEngine;

public class HpBar : GameMonoBehaviour
{
    [Header("Hp Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHp sliderHp;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate()
    {
        this.HpShowing();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSliderHp();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSliderHp()
    {
        if (this.sliderHp != null) return;

        this.sliderHp = GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name + ": LoadSliderHp", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;

        this.followTarget = GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;

        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void HpShowing()
    {
        if (this.shootableObjectCtrl == null) return;

        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(this.transform);
        }

        float hpMax = this.shootableObjectCtrl.DamageReceiver.HPMax;
        float hpCurrent = this.shootableObjectCtrl.DamageReceiver.HpCurrent;

        sliderHp.SetMaxHp(hpMax);
        sliderHp.SetCurrentHp(hpCurrent);
    }

    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}
