using TMPro;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public TextMeshProUGUI WeaponName;


    public void ShowWeaponName(Item item)
    {
        WeaponName.SetText(item.Name);
    }
}
