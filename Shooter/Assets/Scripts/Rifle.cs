using System.Collections;
using UnityEngine;

public class Rifle : Gun
{

    public override void MakeDamege()
    {
        if (base.CurrentAmmoValue > 0)
        {
            base._shooting.Shoot(base._firearmsInfo.FireDistance, base._firearmsInfo.FireRate, base.GunDamage);
        }
    }
}