using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float shipSpeed = 0.01f;

    private void FixedUpdate()
    {
        this.GetTargetPos();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPos - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z);
    }

    protected virtual void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MouseWorldPos;
        this.targetPos.z = 0;
    }

    protected virtual void Moving()
    {

        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPos, shipSpeed);
        transform.parent.position = newPos;
    }
}
