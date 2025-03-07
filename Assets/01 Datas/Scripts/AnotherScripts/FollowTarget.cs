using UnityEngine;

public class FollowTarget : GameMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float followSpeed = 2f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, followSpeed * Time.fixedDeltaTime);
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
