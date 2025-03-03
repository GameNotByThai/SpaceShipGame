public class ObjectLockAtMouse : ObjectLockAtTarget
{
    protected override void FixedUpdate()
    {
        this.GetMousePos();
        base.FixedUpdate();
    }
    protected virtual void GetMousePos()
    {
        this.targetPos = InputManager.Instance.MouseWorldPos;
        this.targetPos.z = 0;
    }
}
