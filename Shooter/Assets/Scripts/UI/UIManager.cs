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

    }

    void Update()
    {
        if (AmmoInfoDisplayer != null)
        {
            AmmoInfoDisplayer.SetCurrentAmmoValueText(Player.Gun.GetCurrentAmmoValue());
            WeaponInfo.ShowWeaponName(Player.Gun.GetGunInfo().Name);
        }
    }


    public void OpenInventory()
    {
        Inventory.SetVisable(true);
    }

    public void CloseInventory()
    {
        Inventory.SetVisable(false);
    }
}
