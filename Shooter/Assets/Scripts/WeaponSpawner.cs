using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Gun WeaponForSpawn;
    public float RotationSpeed;
    private Gun _instance;

    private bool isTake = false;

    void Start()
    {
        _instance = Instantiate(WeaponForSpawn, transform.position, Quaternion.identity);
        _instance.transform.SetParent(transform);
    }

    void Update()
    {
        if (isTake)
        {
            return;
        }
        _instance.transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            //добавить это оружие в инвентать 
            // положить оружие в руку игроку 
            isTake = true;
            _instance.transform.SetParent(null);
            player.SetToMainHand(_instance);

            Destroy(gameObject);
        }
    }
}
