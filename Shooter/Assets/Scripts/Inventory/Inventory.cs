using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> _allItems = new List<Item>();
    [SerializeField]
    private SavingInventorySystem _savingInventorySystem;

    public event Action<Item> OnItemAdd;
    public event Action<Item> OnItemDelete;

    public List<Item> AllItems
    {
        get => _allItems;
    }

    void Start()
    {
        if(_allItems.Count <=0)
        {
            //_allItems = _savingInventorySystem.LoadInventory();
        }
    }

    public void Add(Item item)
    {
        _allItems.Add(item);
        OnItemAdd?.Invoke(item);
        //_savingInventorySystem.SaveInventory(_allItems);
    }

    public void DeleteItem(Item item)
    {
        _allItems.Remove(item);
        OnItemDelete?.Invoke(item);
       // _savingInventorySystem.SaveInventory(_allItems);
    }

    public Item GetItem(int id)
    {
        return _allItems.Find(item => item.Id == id);
    }

    public void ReplaceItem(Item itemToReplace, Item newItem)
    {
        var index = _allItems.FindIndex(obj => obj == itemToReplace);

        if (index != -1)
        {
            _allItems[index] = newItem;
        }
        //_savingInventorySystem.SaveInventory(_allItems);
    }
}
