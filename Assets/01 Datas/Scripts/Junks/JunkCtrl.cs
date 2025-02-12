using UnityEngine;

public class JunkCtrl : GameMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;

    public JunkSpawner JunkSpawner { get => junkSpawner; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;

        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }


}
