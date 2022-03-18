using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedItem : MonoBehaviour
{
    public ItemDescriptionController ItemDescriptionController;
    public InventorySlotsController InventorySlotsController;
    public Inventory Inventory;
    public PlayerHotBar PlayerHotBar;

    [SerializeField]
    private Image image;

    [SerializeField]
    private TextMeshProUGUI _itemName;

    private Item _item;

    public void DisplayItem(InventorySlot slot)
    {
        _item = slot.Item;
        image.sprite = _item.Icon;
        _itemName.SetText(_item.Name);
        ItemDescriptionController.ShowDescription(_item);
    }
    public void DisplayItem()
    {
        image.sprite = _item.Icon;
        _itemName.SetText(_item.Name);
        ItemDescriptionController.ShowDescription(_item);
    }
    public void Equip()
    {
        if (_item.Type == ItemTypes.Weapon)
        {
            var gunInfo = (Firearms) _item.Description;
            if (gunInfo.WeaponTypes == WeaponTypes.Main)
            {
                //убрать дублированный код
                var tmp = PlayerHotBar.FirstSlot;
                PlayerHotBar.FirstSlot = _item;
                Inventory.ReplaceItem(_item, tmp);
                InventorySlotsController.FillSlot(_item, tmp);
                DisplayItem();

            }
            if (gunInfo.WeaponTypes == WeaponTypes.Second)
            {

                var tmp = PlayerHotBar.SecondSlot;
                PlayerHotBar.SecondSlot = _item;
                Inventory.ReplaceItem(_item, tmp);
                InventorySlotsController.FillSlot(_item, tmp);
                DisplayItem();

            }
            if (gunInfo.WeaponTypes == WeaponTypes.OffHand)
            {
                //SwichItemBetweenInventoryAndHotBar(PlayerHotBar.OffHandSlot, _item);
            }
        }
    }

    public void SwichItemBetweenInventoryAndHotBar(Item hotBarItem, Item inventoryItem)
    {
        var tmp = hotBarItem;
        hotBarItem = inventoryItem;
        Inventory.ReplaceItem(inventoryItem, tmp);
        InventorySlotsController.FillSlot(inventoryItem, tmp);
        DisplayItem();
    }
    public void Delete()
    {
        Inventory.DeleteItem(_item);
        InventorySlotsController.CloseSelectedItemPanel();
    }
}
