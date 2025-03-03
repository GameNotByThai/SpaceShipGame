public class ShipShootByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        return InputManager.Instance.OnFiring == 1;
    }
}
