using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : GameMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    public List<ItemSlot> itemSlots;

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 UIHotKeyCtrl allow exsit");
        UIHotKeyCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;

        ItemSlot[] arraySlots = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arraySlots);
        Debug.LogWarning(transform.name + ": LoadItemSlots", gameObject);
    }
}
