using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInfo : MonoBehaviour
{
    public event Action displayInfo;

    [SerializeField]
    private GameObject _currentAmmoValue;

    [SerializeField]
    private GameObject _ammoPacks;
    
    private TextMeshPro _currentAmmoValueComponent;
    private TextMeshPro _ammoPacksComponent;
    void Start()
    {
        _currentAmmoValueComponent = GetComponentInChildren<TextMeshPro>();
        _ammoPacksComponent = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentAmmoValueText(int value)
    {
       // _currentAmmoValueComponent.SetText(value.ToString());
    }
}
