using UnityEngine;
public class MotherShipModify : ObjectModifyAbstract
{
    [Header("Mother Ship")]
    [SerializeField] protected float moveSpeed = 0.01f;
    [SerializeField] protected float rotSpeed = 0.1f;

    protected override void Start()
    {
        base.Start();
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        this.shootableObjectCtrl.ObjectMovement.SetMoveSpeed(moveSpeed);
        this.shootableObjectCtrl.ObjectLockAtTarget.SetRotSpeed(rotSpeed);
    }
}