using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : GameMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Transform realParent;

    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (image != null) return;

        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage", gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.realParent = transform.parent;
        transform.SetParent(UIHotKeyCtrl.Instance.transform);
        this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(realParent);
        this.image.raycastTarget = true;
    }
}
