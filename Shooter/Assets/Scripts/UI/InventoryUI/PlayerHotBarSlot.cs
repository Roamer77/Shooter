using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHotBarSlot : MonoBehaviour
{
    [SerializeField]
    private PlayerHotBar _playerHotBar;

    [SerializeField]
    private Image _firstSlotIcon;
    [SerializeField]
    private Image _secondSlotIcon;
    [SerializeField]
    private Image _offHandSlotIcon;

    void Awake()
    {
        _playerHotBar.OnFirstSlotAdd += ChangeFirstSlotIcon;
        _playerHotBar.OnSecondSlotAdd += ChangeSecondSlotIcon;
        _playerHotBar.OnOffHandAdd += ChangeOffHandSlotIcon;
        ChangeFirstSlotIcon(_playerHotBar.FirstSlot);
        ChangeSecondSlotIcon(_playerHotBar.SecondSlot);
    }
    void OnDisable()
    {
        _playerHotBar.OnFirstSlotAdd -= ChangeFirstSlotIcon;
        _playerHotBar.OnSecondSlotAdd -= ChangeSecondSlotIcon;
        _playerHotBar.OnOffHandAdd -= ChangeOffHandSlotIcon;
    }

    private void ChangeFirstSlotIcon(Item gun)
    {
        if (gun != null)
        {
            _firstSlotIcon.sprite = gun.Icon;
        }
    }
    private void ChangeSecondSlotIcon(Item gun)
    {

        if (gun != null)
        {
            _secondSlotIcon.sprite = gun.Icon;
        }
    }
    private void ChangeOffHandSlotIcon(Item gun)
    {
        if (gun != null)
        {
            _offHandSlotIcon.sprite = gun.Icon;
        }
    }
}
