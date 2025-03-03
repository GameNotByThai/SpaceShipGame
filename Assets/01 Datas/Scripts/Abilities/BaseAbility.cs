using UnityEngine;

public class BaseAbility : GameMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;

    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 3f;
    [SerializeField] protected bool isReady = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilities();
    }

    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;

        this.abilities = transform.parent.GetComponent<Abilities>();
        Debug.LogWarning(transform.name + ": LoadAbilities", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.Timeing();
    }

    protected virtual void Timeing()
    {
        if (this.isReady) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }

    public virtual void Active()
    {
        this.isReady = false;
        this.timer = 0f;
    }
}
