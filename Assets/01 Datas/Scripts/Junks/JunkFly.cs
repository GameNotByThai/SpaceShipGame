using UnityEngine;
public class JunkFly : ParentFly
{
    [SerializeField] protected float minCamPos = -5f;
    [SerializeField] protected float maxCamPos = 5f;

    protected override void ResetValue()
    {
        this.moveSpeed = 0.5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.MainCamera.position;
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(minCamPos, maxCamPos);
        camPos.y += Random.Range(minCamPos, maxCamPos);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);
    }
}
