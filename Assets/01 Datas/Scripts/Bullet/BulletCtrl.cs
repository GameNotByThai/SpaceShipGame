using UnityEngine;

public class BulletCtrl : GameMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;

        damageSender = transform.Find("DamageSender").GetComponent<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }
}
