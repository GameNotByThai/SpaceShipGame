public class BtnOpenInventory : BaseBtn
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
}
