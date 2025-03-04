using UnityEngine;
public class ObjectAppearWithoutShoot : ShootableObjectAbstract, IObjectAppearObserver
{
    [Header("Object Appear Without Shoot")]
    [SerializeField] protected ObjectAppear objectAppear;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }

    protected virtual void RegisterAppearEvent()
    {
        this.objectAppear.AddObserver(this);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjectAppear();
    }
    protected virtual void LoadObjectAppear()
    {
        if (this.objectAppear != null) return;

        this.objectAppear = GetComponent<ObjectAppear>();
        Debug.LogWarning(transform.name + ": LoadObjectAppear", gameObject);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjectShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjectLockAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjectShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.ObjectLockAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtrl.Spawner.Hold(transform.parent);
    }
}
