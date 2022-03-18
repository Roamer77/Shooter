using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlotsController : MonoBehaviour
{
    public Animator Animator;

    [SerializeField]
    private GameObject _inventorySlots;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private GameObject _closeInventoryButton;

    [SerializeField]
    private SelectedItem _selectedItemPanel;

    public List<InventorySlot> Slots { get; private set; }

    private bool AnimatinPlay = false;
    private InventorySlot _previousSlot;

    private void Awake()
    {
        Slots = new List<InventorySlot>();

        for (var i = 0; i < _inventorySlots.transform.childCount; i++)
        {
            var item = _inventorySlots.transform.GetChild(i).GetComponent<InventorySlot>();
            Slots.Add(item);
            item.OnSelected += OnItemPress;
        }
        for (int i = 0; i < _inventory.AllItems.Count; i++)
        {
            Slots[i].AddItem(_inventory.AllItems[i]);
        }
    }
    void Start()
    {
        _inventory.OnItemDelete += RemoveSlot;
    }


    void OnDestroy()
    {
        _inventory.OnItemDelete -= RemoveSlot;
    }

    public void FillSlot(Item itemToReplace, Item newItem)
    {
        var index = Slots.FindIndex(slot => slot.Item == itemToReplace);
        if(index != -1)
        {
            Slots[index].AddItem(newItem);
        }
    }

    private void RemoveSlot(Item item)
    {
        var currentSlot = Slots.Find(slot => slot.Item == item);
        Slots.Remove(currentSlot);
        currentSlot.ClearSlot();
    }

    public void OnItemPress(InventorySlot currentSlot)
    {
        if(currentSlot.Item != null)
        {
            if (!AnimatinPlay)
            {
                Animator.Play("SelectInventoryItem");
                AnimatinPlay = true;
                _closeInventoryButton.SetActive(false);
                _selectedItemPanel.gameObject.SetActive(true);

            }
            if (_previousSlot && _previousSlot != currentSlot)
            {
                _previousSlot.Diselect();
            }
            currentSlot.Select();
            _previousSlot = currentSlot;
            _selectedItemPanel.DisplayItem(currentSlot); 
        }
        

    }
    public void CloseSelectedItemPanel()
    {
        if (AnimatinPlay)
        {
            Animator.Play("CloseSelectedItemPanal");
            _previousSlot.Diselect();
            AnimatinPlay = false;
            _closeInventoryButton.SetActive(true);
            _selectedItemPanel.gameObject.SetActive(false);
        }
    }

}
