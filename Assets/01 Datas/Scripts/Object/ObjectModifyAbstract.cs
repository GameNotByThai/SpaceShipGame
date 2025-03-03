using UnityEngine;

public abstract class ObjectModifyAbstract : GameMonoBehaviour
{
    [Header("Modify Abstract")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (shootableObjectCtrl != null) return;

        this.shootableObjectCtrl = GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }
}