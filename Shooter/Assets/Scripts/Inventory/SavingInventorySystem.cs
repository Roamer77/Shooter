using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavingInventorySystem : MonoBehaviour
{
    public  InventoryData InventoryData;
    
    public  void SaveInventory(List<Item> items)
    {
        InventoryData.AllItems = items;
    }
    public  List<Item> LoadInventory()
    {
        return InventoryData.AllItems;
    }
}
