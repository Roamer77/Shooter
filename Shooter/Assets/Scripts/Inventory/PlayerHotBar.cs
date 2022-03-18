using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHotBar : MonoBehaviour
{
    public event Action<Item> OnFirstSlotAdd;
    public event Action<Item> OnSecondSlotAdd;
    public event Action<Item> OnOffHandAdd;
    private Item _firstSlot;
    private Item _secondSlot;
    private Item _offHandSlot;

    public Dictionary<int, Item> AllGuns = new Dictionary<int, Item>();
    public Item FirstSlot
    {
        get
        {
            return _firstSlot;
        }
        set
        {
            _firstSlot = value;
            AllGuns[0] = value;
            Debug.Log("Change first slot");
            OnFirstSlotAdd?.Invoke(value);
        }
    }

    public Item SecondSlot
    {
        get
        {
            return _secondSlot;
        }
        set
        {
            _secondSlot = value;
            AllGuns[1] = value;
            Debug.Log("Change second slot");
            OnSecondSlotAdd?.Invoke(value);
        }
    }

    public Item OffHandSlot
    {
        get
        {
            return _offHandSlot;
        }
        set
        {
            _offHandSlot = value;
            AllGuns[2] = value;
            OnOffHandAdd?.Invoke(value);
        }
    }
}
