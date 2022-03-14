using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsOnPlayerBar : MonoBehaviour
{
    public List<OnPlayerBarSlot> Slots;


    public void Add(Item item)
    {
        for (var i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].Type == item.SlotType && Slots[i].isEmply)
            {
                Slots[i].Add(item);
                return;
            }
        }

    }

    public bool IsMainSlotsEmpty()
    {
        foreach (var slot in Slots)
        {
            if (slot.isEmply == true)
            {
                Debug.Log("Done");
                return true;
            }
        }
        return false;
    }

}
