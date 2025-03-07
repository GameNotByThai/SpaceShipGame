public class TextShipHp : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHp();
    }

    protected virtual void UpdateShipHp()
    {
        int currentHp = PlayerCtrl.Instance.CurentShip.DamageReceiver.HpCurrent;
        int maxHp = PlayerCtrl.Instance.CurentShip.DamageReceiver.HPMax;
        this.text.SetText(currentHp + " / " + maxHp);
    }
}
