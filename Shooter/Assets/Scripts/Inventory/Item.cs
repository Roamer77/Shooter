using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New item")]
[Serializable]

public class Item : ScriptableObject
{
    public int Id;

    public string Name;
    public GameObject Prefub;

    public ScriptableObject Description;

    public Sprite Icon;

    public ItemTypes Type;
    
}
