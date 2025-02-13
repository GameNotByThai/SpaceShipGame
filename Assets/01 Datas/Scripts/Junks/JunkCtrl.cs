using UnityEngine;

public class JunkCtrl : GameMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.Model != null) return;

        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
