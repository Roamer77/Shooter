using TMPro;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public TextMeshProUGUI WeaponName;

    public void ShowWeaponName(string name)
    {
        WeaponName.SetText(name);
    }
}
