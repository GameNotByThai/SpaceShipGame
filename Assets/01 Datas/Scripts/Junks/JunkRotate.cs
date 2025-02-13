using UnityEngine;

public class JunkRotate : JunkAbtrack
{
    [SerializeField] protected float rotateSpeed = 20f;

    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Rotating()
    {
        Vector3 euler = new Vector3(0, 0, 1);
        this.junkCtrl.Model.Rotate(euler * rotateSpeed * Time.fixedDeltaTime);
    }
}
