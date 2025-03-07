using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("Warp")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected float warpSpeed = 1f;
    [SerializeField] protected float warpDistance = 2f;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] protected Vector4 warpDirection;
    protected Vector4 keyDirection;

    protected override void Update()
    {
        base.Update();
        this.CheckWarpDirection();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }

    protected virtual void CheckWarpDirection()
    {
        if (!this.isReady) return;
        if (this.isWarping) return;

        if (this.keyDirection.x == 1) this.WarpLeft();
        if (this.keyDirection.y == 1) this.WarpRight();
        if (this.keyDirection.z == 1) this.WarpUp();
        if (this.keyDirection.w == 1) this.WarpDown();
    }

    protected virtual void Warping()
    {
        if (isWarping) return;
        if (this.IsDirectionNotSet()) return;

        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);
    }

    protected virtual void WarpLeft()
    {
        Debug.Log("Warp Left");
        this.warpDirection.x = 1;
    }

    protected virtual void WarpRight()
    {
        Debug.Log("Warp Right");
        this.warpDirection.y = 1;
    }

    protected virtual void WarpUp()
    {
        Debug.Log("Warp Up");
        this.warpDirection.z = 1;
    }

    protected virtual void WarpDown()
    {
        Debug.Log("Warp Down");
        this.warpDirection.w = 1;
    }

    protected virtual bool IsDirectionNotSet()
    {
        return this.warpDirection.x == 0 && this.warpDirection.y == 0
            && this.warpDirection.z == 0 && this.warpDirection.w == 0;
    }

    protected virtual void WarpFinish()
    {
        this.MoveObject();
        this.warpDirection.Set(0, 0, 0, 0);
        this.isWarping = false;
        this.Active();
    }

    protected virtual void MoveObject()
    {
        Transform obj = this.abilities.AbilityObjectCtrl.transform;
        Vector3 newPos = obj.position;
        if (this.warpDirection.x == 1) newPos.x -= warpDistance;
        if (this.warpDirection.y == 1) newPos.x += warpDistance;
        if (this.warpDirection.z == 1) newPos.y += warpDistance;
        if (this.warpDirection.w == 1) newPos.y -= warpDistance;

        Quaternion fxRot = GetFXQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.Impact_1, obj.position, fxRot);
        fx.gameObject.SetActive(true);

        obj.position = newPos;
    }

    protected virtual Quaternion GetFXQuaternion()
    {
        Vector3 vector = new Vector3();
        if (this.warpDirection.x == 1) vector.z = 90;
        if (this.warpDirection.y == 1) vector.z = -90;
        if (this.warpDirection.z == 1) vector.z = 0;
        if (this.warpDirection.w == 1) vector.z = 180;

        if (this.warpDirection.x == 1 && this.warpDirection.w == 1) vector.z = -45;
        if (this.warpDirection.x == 1 && this.warpDirection.z == 1) vector.z = -135;
        if (this.warpDirection.y == 1 && this.warpDirection.w == 1) vector.z = 45;
        if (this.warpDirection.y == 1 && this.warpDirection.z == 1) vector.z = 135;

        return Quaternion.Euler(vector);
    }
}
