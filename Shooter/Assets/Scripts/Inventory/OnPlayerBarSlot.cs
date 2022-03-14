using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPlayerBarSlot : MonoBehaviour
{
    public Image icon;
    public bool isEmply;
    public Item Item {get; private set;}
    public SlotTypes Type;

    void Awake() {
        isEmply = true;
    }
    public void Add(Item item)
    {
        Item = item;
        icon.sprite = Item.Icon;
        isEmply = false;
    }
}
