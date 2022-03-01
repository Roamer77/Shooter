using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject WeaponPlace;

    public Gun Gun;

    public float Speed;

    
    void Start()
    {
        PlaceWeapon();
    }

    public void SetToMainHand(Gun instance)
    {
        Destroy(Gun.gameObject);
        Gun = instance;
        Gun.transform.SetParent(transform);
        PlaceWeapon();
        Gun.transform.localRotation = new Quaternion(0,180f,0,0);
    }

    public void PlaceWeapon()
    {
        Gun.transform.position = WeaponPlace.transform.position;
    }
}
