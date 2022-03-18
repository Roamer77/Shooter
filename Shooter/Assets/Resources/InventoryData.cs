using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/New inventoryData")]
public class InventoryData : ScriptableObject
{
    public List<Item> AllItems {get; set;}
}
