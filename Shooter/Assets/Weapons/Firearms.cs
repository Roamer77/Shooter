using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Firearm", menuName = "Weapon/New firearm")]
public class Firearms : ScriptableObject
{
    public string Name;
    public float FireRate;

    public int BulletAmount;

    public float FireDistance ;
}
