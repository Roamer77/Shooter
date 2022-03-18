using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Firearm", menuName = "Weapon/New firearm")]
public class Firearms : ScriptableObject
{
    public Stat FireRate;

    public Stat BulletAmount;

    public Stat FireDistance;

    public Stat Damege;

    public WeaponTypes WeaponTypes;

    public Dictionary<int,Stat> GetAllStats()
    {
        var dictionary = new Dictionary<int, Stat>();
        dictionary.Add(0,FireRate);
        dictionary.Add(1,BulletAmount);
        dictionary.Add(2,FireDistance);
        dictionary.Add(3,Damege);
        return dictionary;
    }
}
