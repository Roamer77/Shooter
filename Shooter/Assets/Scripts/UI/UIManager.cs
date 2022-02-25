using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AmmoInfo AmmoInfoDisplayer;

    public Player Player;

    void Start()
    {

    }

    void Update()
    {
        if (AmmoInfoDisplayer != null)
        {
            AmmoInfoDisplayer.SetCurrentAmmoValueText(Player.Gun.GetCurrentAmmoValue());
        }
    }
}
