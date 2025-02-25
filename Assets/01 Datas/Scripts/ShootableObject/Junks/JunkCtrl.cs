using UnityEngine;

public class JunkCtrl : GameMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected ShootableObjectSO junkSO;
    public ShootableObjectSO JunkSO => junkSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null) return;

        string resPath = "ShootableObject/Junk/" + transform.name;
        this.junkSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadJunkSO", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.Model != null) return;

        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.JunkDespawn != null) return;

        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.LogWarning(transform.name + ": LoadJunkDespawn", gameObject);
    }
}
