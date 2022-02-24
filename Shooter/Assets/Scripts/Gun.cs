using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    private float _fireRate = .75f;

    private float _bulletAmount = 15;

    private float _fireDistance = 10;

    [SerializeField]
    private Shooting _shooting;

    public void MakeDamege()
    {
        _shooting.Shoot(_fireDistance, _fireRate);
    }
}
