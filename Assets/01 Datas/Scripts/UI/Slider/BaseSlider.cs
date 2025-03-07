using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : GameMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        base.Start();
        this.AddOnValueChangedEvent();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;

        this.slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }

    protected virtual void AddOnValueChangedEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnValueChanged);
    }

    protected abstract void OnValueChanged(float newValue);
}
