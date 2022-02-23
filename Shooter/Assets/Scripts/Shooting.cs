using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private RaycastHit _hit;

    public void Shoot(Ray _aimingRay, float distance)
    {
        //добавить маску для raycast
        if (Physics.Raycast(_aimingRay.origin, _aimingRay.direction, out _hit, distance))
        {
            Debug.Log("Hit");
            var hitForce = 10;
            if (_hit.rigidbody != null)
            {
                _hit.rigidbody.AddForce(-_hit.normal * hitForce);
            }
        }
    }
}
