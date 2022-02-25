using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{

    [SerializeField]
    protected Firearms _firearmsInfo;

    [SerializeField]
    protected Shooting _shooting;

    protected int _currentAmmoValue;

    void Start() 
    {
        _currentAmmoValue = _firearmsInfo.BulletAmount;
    }

    public virtual void MakeDamege()
    {
        if(_currentAmmoValue > 1)
        {
         StartCoroutine(ShootingQueue());
        }
    }
    private IEnumerator ShootingQueue()
    {
        _shooting.Shoot(_firearmsInfo.FireDistance,_firearmsInfo.FireRate, ref _currentAmmoValue);
        yield return new WaitForSeconds(.2f);
        _shooting.Shoot(_firearmsInfo.FireDistance,_firearmsInfo.FireRate, ref _currentAmmoValue);
        yield return new WaitForSeconds(.2f);
        _shooting.Shoot(_firearmsInfo.FireDistance,_firearmsInfo.FireRate, ref _currentAmmoValue);
    }

    public Firearms GetAimDistance () => _firearmsInfo;

    public int GetCurrentAmmoValue() => _currentAmmoValue;

}
