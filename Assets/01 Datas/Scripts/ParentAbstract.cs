using UnityEngine;

public abstract class ParentAbstract<T> : GameMonoBehaviour where T : GameMonoBehaviour
{
    [Header("Abstract Ctrl")]
    [SerializeField] private T parentCtr;
    public T ParentCtrl => parentCtr;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadParentCtrl();
    }

    private void LoadParentCtrl()
    {
        if (this.parentCtr != null) return;

        this.parentCtr = transform.parent.GetComponent<T>();
        Debug.Log(transform.name + ": LoadParentCtrl", gameObject);
    }

}