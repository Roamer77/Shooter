using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Gun WeaponForSpawn;
    public float RotationSpeed;

    [SerializeField]
    private Inventory _inventory;

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

            isTake = true;

            // есть ли в 1 или 2 руке что-то. если нет то закинуть в руку
            // если  есть то закинуть в инвентать 
            if (_inventory.IsPlayerMainSlotsEmpty())
            {
                _inventory.AddToOnPlayerSlots(_instance.GetComponent<Item>());

                _instance.transform.SetParent(null);
                player.SetToMainHand(_instance);
                Destroy(gameObject);
            }
            else
            {
                AddItemToInventory();
                Destroy(gameObject);
            }

        }
    }

    private void AddItemToInventory()
    {
        var item = _instance.GetComponent<Item>();
        if (item != null)
        {
            _inventory.Add(item);
        }
    }
}
