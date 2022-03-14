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
    private GameObject _closeInventoryButton;

    [SerializeField]
    private GameObject _selectedItemPanel;

    public List<InventorySlot> Slots {get; private set;}

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
    }


    public void OnItemPress(InventorySlot currentSlot)
    {
        if (!AnimatinPlay)
        {
            Animator.Play("SelectInventoryItem");
            AnimatinPlay = true;
            _closeInventoryButton.SetActive(false);
            _selectedItemPanel.SetActive(true);
        }
        if (_previousSlot && _previousSlot != currentSlot)
        {
            _previousSlot.Diselect();
        }
        currentSlot.Select();
        _previousSlot = currentSlot;

    }
    public void CloseSelectedItemPanel()
    {
        if (AnimatinPlay)
        {
            Animator.Play("CloseSelectedItemPanal");
            _previousSlot.Diselect();
            AnimatinPlay = false;
            _closeInventoryButton.SetActive(true);
              _selectedItemPanel.SetActive(false);
        }
    }

}
