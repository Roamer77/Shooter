using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
    [SerializeField]
    private InventorySlotsController _inventorySlotsController;

    [SerializeField]
    private ItemsOnPlayerBar _itemsOnPlayerBar;

    private List<InventorySlot> _slots;

    void Awake()
    {
        _slots = _inventorySlotsController.Slots;
    }

    public void Add(Item item)
    {
        for (var i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].isEmply)
            {
                _slots[i].AddItem(item);
                _slots[i].isEmply = false;
                return;
            }
        }

    }

    public void Delete(int index)
    {
        if (index <= _slots.Count)
        {
            _slots.RemoveAt(index);
        }
    }

    public Item Get(int index)
    {
        if (index <= _slots.Count)
        {
            return _slots[index].Item;
        }
        return null;
    }

    public void AddToOnPlayerSlots(Item item)
    {
        _itemsOnPlayerBar.Add(item);
    }

    public bool IsPlayerMainSlotsEmpty()
    {
        return _itemsOnPlayerBar.IsMainSlotsEmpty();
    }

}
