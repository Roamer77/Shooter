using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event Action<Item> onGunChanged; 
    public GameObject WeaponPlace;

    public Gun Gun;

    public float Speed;

    public PlayerHotBar PlayerHotBar;

    private PlayerInput _playerInput;

    private int currentGunIndex = 0;
    private int AvaleableSlots = 1;
    void Start()
    {
        PlaceWeapon();
        PlayerHotBar.OnFirstSlotAdd += SetToMainHand;
    }
    void OnDestroy()
    {
        PlayerHotBar.OnFirstSlotAdd -= SetToMainHand;
    }
    public void SwichGuns()
    {
        if (currentGunIndex > AvaleableSlots)
        {
            currentGunIndex = 0;
        }
        SetToMainHand(PlayerHotBar.AllGuns[currentGunIndex]);
        currentGunIndex++;
    }

    public void SetToMainHand(Item item)
    {
        if (Gun != null)
        {
            Destroy(Gun.gameObject);
        }
        var instance = item.Prefub.GetComponent<Gun>();
        var newGun = Instantiate(instance, Vector3.zero, Quaternion.identity);
        Gun = newGun;
        Gun.transform.SetParent(transform);
        PlaceWeapon();
        Gun.transform.localRotation = new Quaternion(0, 180f, 0, 0);
        onGunChanged?.Invoke(item);
    }

    public void PlaceWeapon()
    {
        if (Gun != null)
            Gun.transform.position = WeaponPlace.transform.position;
    }
}
