using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private GameObject _onCharPanelController;

    [SerializeField]
    private GameObject _inventorySlotsController;

    
    [SerializeField]
    private GameObject _closeButton;

    [SerializeField]
    private GameObject _backGround;

    private List<GameObject> _onCharPanelChileds = new List<GameObject>();
    private List<GameObject> _inventorySlotsChileds = new List<GameObject>();
    void Start() 
    {
        for (int i = 0; i < _onCharPanelController.transform.childCount; i++)
        {
            _onCharPanelChileds.Add(_onCharPanelController.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < _inventorySlotsController.transform.childCount; i++)
        {
            _inventorySlotsChileds.Add(_inventorySlotsController.transform.GetChild(i).gameObject);
        }
    }

    public void SetVisable(bool state)
    {
        _closeButton.SetActive(state);
        _backGround.SetActive(state);
        
        foreach (var item in _onCharPanelChileds)
        {
            item.SetActive(state);
        }
        foreach (var item in _inventorySlotsChileds)
        {
            item.SetActive(state);
        }
    }
}
