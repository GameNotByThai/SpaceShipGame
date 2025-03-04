using UnityEngine;
public abstract class ObjectMovement : GameMonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float shipSpeed = 0.5f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    public virtual void SetMoveSpeed(float newSpeed)
    {
        this.shipSpeed = newSpeed;
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPos);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPos, shipSpeed * Time.fixedDeltaTime);
        transform.parent.position = newPos;
    }
}
