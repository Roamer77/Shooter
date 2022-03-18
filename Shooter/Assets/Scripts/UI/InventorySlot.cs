using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public event Action<InventorySlot> OnSelected;

    public bool isEmply = true;

    public Item Item;

    [SerializeField]
    private Image _slotBackgroud;

    [SerializeField]
    private Image _slotSelector;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private TextMeshProUGUI _amount;

    public void Select()
    {
        _slotSelector.color = Color.black;
    }
    public void Diselect()
    {
        _slotSelector.color = Color.white;
    }

    public void AddItem(Item item)
    {
        this.Item = item;
        _itemIcon.gameObject.SetActive(true);
        _amount.transform.parent.gameObject.SetActive(true);
        _itemIcon.sprite = item.Icon;
        _amount.SetText("1");
    }

    public void ClearSlot()
    {
        _itemIcon.gameObject.SetActive(false);
        _amount.transform.parent.gameObject.SetActive(false);
        _itemIcon.sprite = null;
        this.Item = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelected?.Invoke(this);
    }
}
