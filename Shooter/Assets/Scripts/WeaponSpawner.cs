using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Gun WeaponForSpawn;
    public float RotationSpeed;
    private Gun _instance;

    void Start()
    {
        _instance = Instantiate(WeaponForSpawn, transform.position, Quaternion.identity);
        _instance.transform.SetParent(transform);
    }

    void Update() 
    {
        _instance.transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
           var player = other.gameObject.GetComponent<PlayerController>();
           //добавить это оружие в инвентать 
           // положить оружие в руку игроку 
        }
    }
}
