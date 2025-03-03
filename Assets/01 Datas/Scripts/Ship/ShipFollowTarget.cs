using UnityEngine;

public class ShipFollowTarget : ObjectMovement
{
    [Header("Follow Target")]
    [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        this.GetTargetPos();
        base.FixedUpdate();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void GetTargetPos()
    {
        this.targetPos = this.target.position;
        this.targetPos.z = 0;
    }
}
