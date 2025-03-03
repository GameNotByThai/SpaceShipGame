using UnityEngine;
public class ObjectMoveFoward : ObjectMovement
{
    [SerializeField] protected Transform moveTarget;

    protected override void FixedUpdate()
    {
        this.GetMousePos();
        base.FixedUpdate();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMoveTarget();
    }

    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;

        this.moveTarget = transform.Find("MoveFoward");
        this.moveTarget.position = new Vector3(7f, 0f, 0f);
        Debug.LogWarning(transform.name + ": LoadMoveTarget", gameObject);
    }

    protected virtual void GetMousePos()
    {
        this.targetPos = moveTarget.position;
        this.targetPos.z = 0;
    }
}
