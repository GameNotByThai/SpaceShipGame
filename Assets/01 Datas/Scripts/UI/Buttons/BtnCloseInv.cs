public class BtnCloseInv : BaseBtn
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
