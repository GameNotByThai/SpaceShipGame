using UnityEngine;

public class ShipShootByDistance : ObjectShooting
{
    [Header("Shoot By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistacne = 3f;

    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, this.target.position);
        return this.distance < this.shootDistacne;
    }
}
