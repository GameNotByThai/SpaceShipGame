using UnityEngine;

public abstract class ShootableObjectCtrl : GameMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn shootableObjDespawn;
    public Despawn ShootableObjDespawn => shootableObjDespawn;

    [SerializeField] protected ShootableObjectSO shootableObjSO;
    public ShootableObjectSO ShootableObjSO => shootableObjSO;

    [SerializeField] protected ObjectShooting objectShooting;
    public ObjectShooting ObjectShooting => objectShooting;

    [SerializeField] protected ObjectMovement objectMovement;
    public ObjectMovement ObjectMovement => objectMovement;

    [SerializeField] protected ObjectLockAtTarget objectLockAtTarget;
    public ObjectLockAtTarget ObjectLockAtTarget => objectLockAtTarget;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjectShooting();
        this.LoadObjectMovement();
        this.LoadObjectLockAtTarget();
    }

    protected virtual void LoadModel()
    {
        if (this.Model != null) return;

        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.shootableObjDespawn != null) return;

        this.shootableObjDespawn = transform.GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name + ": LoadDespawn", gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObjSO != null) return;

        string resPath = "ShootableObject/" + this.GetSONameToString() + "/" + transform.name;
        this.shootableObjSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadSO", gameObject);
    }

    protected virtual void LoadObjectShooting()
    {
        if (this.objectShooting != null) return;

        this.objectShooting = transform.GetComponentInChildren<ObjectShooting>();
        Debug.LogWarning(transform.name + ": LoadObjectShooting", gameObject);
    }
    protected virtual void LoadObjectMovement()
    {
        if (this.objectMovement != null) return;

        this.objectMovement = transform.GetComponentInChildren<ObjectMovement>();
        Debug.LogWarning(transform.name + ": LoadObjectMovement", gameObject);
    }
    protected virtual void LoadObjectLockAtTarget()
    {
        if (this.objectLockAtTarget != null) return;

        this.objectLockAtTarget = transform.GetComponentInChildren<ObjectLockAtTarget>();
        Debug.LogWarning(transform.name + ": LoadObjectLockAtTarget", gameObject);
    }

    protected abstract string GetSONameToString();
}
