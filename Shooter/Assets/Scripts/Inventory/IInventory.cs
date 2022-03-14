using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory 
{
   void Add(Item item);
   void Delete(int index);

   Item Get(int index);
}
