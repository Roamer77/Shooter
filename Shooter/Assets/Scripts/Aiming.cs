using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float Distance;
    private Ray _ray;

    public LineRenderer AimLine;
    public float AimDistance;
    public Transform Player;
    
    void Start()
    {
          
    }
    void Update() 
    {
        Aim(Player.rotation);
            
    }
    public void Aim( Quaternion playerRotation)
    {
        _ray = new Ray(Player.position,  playerRotation * Vector3.forward);  
        Debug.DrawRay(_ray.origin, _ray.direction * Distance);    
    }
}
