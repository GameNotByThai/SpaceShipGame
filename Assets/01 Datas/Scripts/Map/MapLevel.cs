public class MapLevel : LevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTarget();
    }

    private void MapSetTarget()
    {
        if (this.target != null) return;

        ShipCtrl currentShip = PlayerCtrl.Instance.CurentShip;
        this.SetTarget(currentShip.transform);
    }
}
