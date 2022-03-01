using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _currentAmmoValueComponent;

     [SerializeField]
    private TextMeshProUGUI _ammoPacksComponent;
    
    public void SetCurrentAmmoValueText(int value)
    {
       _currentAmmoValueComponent.SetText(value.ToString());
    }
}
