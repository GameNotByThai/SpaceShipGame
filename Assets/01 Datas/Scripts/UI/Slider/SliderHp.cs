using UnityEngine;

public class SliderHp : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float maxHp = 100f;
    [SerializeField] protected float currentHp = 70f;

    protected virtual void FixedUpdate()
    {
        this.ShowingHp();
    }

    protected virtual void ShowingHp()
    {
        float hpPercent = this.currentHp / this.maxHp;
        this.slider.value = hpPercent;
    }

    public virtual void SetMaxHp(float newMaxHp)
    {
        this.maxHp = newMaxHp;
    }

    public virtual void SetCurrentHp(float newCurrentHp)
    {
        this.currentHp = newCurrentHp;
    }

    protected override void OnValueChanged(float newValue)
    {
        //Debug.Log("New value: " + newValue);
    }
}
