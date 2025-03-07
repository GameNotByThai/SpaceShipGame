using TMPro;
using UnityEngine;

public abstract class BaseText : GameMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.text != null) return;

        this.text = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }
}
