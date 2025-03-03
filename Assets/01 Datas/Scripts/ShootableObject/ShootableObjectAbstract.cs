using UnityEngine;

public abstract class ShootableObjectAbstract : GameMonoBehaviour
{
    [Header("Shootable Object Abstract")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;

        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.LogWarning(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }

}