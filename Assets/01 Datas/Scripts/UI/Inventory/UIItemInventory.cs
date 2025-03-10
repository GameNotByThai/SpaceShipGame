using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIItemInventory : GameMonoBehaviour
{
    [Header("UI Item Inventory")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Image itemImage;
    public Image ItemImage => itemImage;

    [SerializeField] protected TextMeshProUGUI itemName;
    public TextMeshProUGUI ItemName => itemName;

    [SerializeField] protected TextMeshProUGUI itemNumber;
    public TextMeshProUGUI ItemNumber => itemNumber;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //this.LoadItemInventory();
        this.LoadItemName();
        this.LoadItemNumber();
        this.LoadItemImage();
    }
    //protected virtual void LoadItemInventory()
    //{
    //    if (itemInventory != null) return;

    //    this.itemInventory =
    //    Debug.LogWarning(transform.name + ": LoadItemInventory", gameObject);
    //}

    protected virtual void LoadItemName()
    {
        if (itemName != null) return;

        this.itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumber()
    {
        if (itemNumber != null) return;

        this.itemNumber = transform.Find("ItemNumber").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadItemNumber", gameObject);
    }

    protected virtual void LoadItemImage()
    {
        if (itemImage != null) return;

        this.itemImage = transform.Find("ItemImage").GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadItemImage", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = this.itemInventory.itemProfileSO.name;
        this.itemNumber.text = this.itemInventory.itemCount.ToString();
        this.itemImage.sprite = this.itemInventory.itemProfileSO.itemSprite;
    }
}
