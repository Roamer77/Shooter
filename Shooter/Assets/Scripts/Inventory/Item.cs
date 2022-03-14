using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefub;
   
    public int Amount;

    public Sprite Icon;

    public string Description;

    public SlotTypes SlotType;

    public ItemType Type;

}
