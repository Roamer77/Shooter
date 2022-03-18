using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AmmoInfo AmmoInfoDisplayer;

    public WeaponInfo WeaponInfo;

    public InventoryController Inventory;

    public Player Player;

    void Start()
    {
        Player.onGunChanged += WeaponInfo.ShowWeaponName;
    }
    void OnDestroy()
    {
        Player.onGunChanged -= WeaponInfo.ShowWeaponName;
    }

    void Update()
    {
        if (Player.Gun != null)
        {
            AmmoInfoDisplayer.SetCurrentAmmoValueText(Player.Gun.GetCurrentAmmoValue());
        }
    }


    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        Inventory.gameObject.SetActive(false);
    }
}
