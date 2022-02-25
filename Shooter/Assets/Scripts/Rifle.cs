using System.Collections;
using UnityEngine;

public class Rifle : Gun
{
    public override void MakeDamege()
    {
        if (base._currentAmmoValue > 0)
        {
            base._shooting.Shoot(base._firearmsInfo.FireDistance, base._firearmsInfo.FireRate, ref base._currentAmmoValue);
        }
    }
}