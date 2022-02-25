using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private RaycastHit _hit;
    private float _lastShootTime;

    private ParticleSystem _fireEffect;

    public Transform BulletSpawnPoint;

    public LayerMask Layer;

    public TrailRenderer BulletTrail;

    public GameObject FireEffect;

    public ParticleSystem InjuryEffect;

    private int _damgeValue = 1;

    void Start()
    {
        _fireEffect = FireEffect.GetComponentInChildren<ParticleSystem>();
    }
    public void Shoot(float distance, float fireRate, ref int currentAmmoValue)
    {
        if (_lastShootTime + fireRate < Time.time)
        {
            _hit = new RaycastHit();
            var ray = new Ray(BulletSpawnPoint.position, BulletSpawnPoint.forward * -distance);

            Physics.Raycast(ray.origin, ray.direction, out _hit, distance, Layer);

            var buliteTrail = InitTrail(distance);

            if (currentAmmoValue != 0)
            {
                currentAmmoValue--;
            }

            if (_hit.collider != null)
            {
                var target = _hit.collider.GetComponent<Target>();
                StartCoroutine(SpawnTrail(buliteTrail, _hit.point));

                _lastShootTime = Time.time;
                if (target != null)
                {
                    CreateInjuryEffect();
                    target.Damege(_damgeValue);
                }
            }
            else
            {
                var maxFireDistance = BulletSpawnPoint.position + BulletSpawnPoint.forward * -distance;
                StartCoroutine(SpawnTrail(buliteTrail, maxFireDistance));
                _lastShootTime = Time.time;
            }

        }

    }

    private void CreateInjuryEffect()
    {
        var injuryEffect = Instantiate(InjuryEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
        injuryEffect.Play();
        Destroy(injuryEffect, 1f);
    }

    private TrailRenderer InitTrail(float distnce)
    {
        var buliteTrail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
        buliteTrail.gameObject.SetActive(true);
        return buliteTrail;
    }

    private IEnumerator SpawnTrail(TrailRenderer bulletTrail, Vector3 trilEndPoint)
    {
        float time = 0;
        while (time < 1)
        {
            bulletTrail.transform.position = Vector3.Lerp(BulletSpawnPoint.position, trilEndPoint, time);
            time += Time.deltaTime / bulletTrail.time;
            yield return null;
        }
        _fireEffect.Play();
        bulletTrail.transform.position = trilEndPoint;
        Destroy(bulletTrail.gameObject, bulletTrail.time);
    }
}
