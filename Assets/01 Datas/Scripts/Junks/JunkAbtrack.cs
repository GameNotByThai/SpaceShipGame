using UnityEngine;

public class JunkAbtrack : GameMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl { get => junkCtrl; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;

        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.LogWarning(transform.name + ": LoadJunkCtrl", gameObject);
    }
}
