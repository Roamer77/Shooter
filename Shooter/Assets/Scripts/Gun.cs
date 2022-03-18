using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField]
    protected Firearms _firearmsInfo;

    [SerializeField]
    protected Shooting _shooting;
    public ParticleSystem FireEffect;
    public ParticleSystem InjuryEffect;

    public Bullet Bullet;

    protected int GunDamage;

    [HideInInspector]
    public int CurrentAmmoValue;

    public Firearms FirearmsInfo
    {
        get => _firearmsInfo;
    }
    void Start()
    {
        CurrentAmmoValue = (int)_firearmsInfo.BulletAmount.Value;
        GunDamage = (int)_firearmsInfo.Damege.Value  + Bullet.Damage;
    }

    public virtual void MakeDamege()
    {
        if (CurrentAmmoValue > 1)
        {
            StartCoroutine(ShootingQueue());
        }
    }
    private IEnumerator ShootingQueue()
    {
        _shooting.Shoot(_firearmsInfo.FireDistance.Value, _firearmsInfo.FireRate.Value, GunDamage);
        yield return new WaitForSeconds(.2f);
        _shooting.Shoot(_firearmsInfo.FireDistance.Value, _firearmsInfo.FireRate.Value, GunDamage);
        yield return new WaitForSeconds(.2f);
        _shooting.Shoot(_firearmsInfo.FireDistance.Value, _firearmsInfo.FireRate.Value, GunDamage);
    }

    public Firearms GetGunInfo() => _firearmsInfo;

    public int GetCurrentAmmoValue() => CurrentAmmoValue;

}
