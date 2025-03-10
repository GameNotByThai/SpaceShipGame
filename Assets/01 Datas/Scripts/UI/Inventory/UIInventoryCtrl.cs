using UnityEngine;
public class UIInventoryCtrl : GameMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [Header("Inv Item Spawner")]
    [SerializeField] protected UIInvItemSpawner uiInvItemSpawner;
    public UIInvItemSpawner UIInvItemSpawner => uiInvItemSpawner;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadContent();
        this.LoadUIInvItemSpawner();
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning(transform.name + ": LoadHolder", gameObject);
    }
    protected virtual void LoadUIInvItemSpawner()
    {
        if (this.uiInvItemSpawner != null) return;
        this.uiInvItemSpawner = transform.GetComponentInChildren<UIInvItemSpawner>();
        Debug.LogWarning(transform.name + ": LoadUIInvItemSpawner", gameObject);
    }
}
