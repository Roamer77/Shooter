using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public PlayerHotBar PlayerHotBar;
    public Inventory PlayerInventorty;

    public Item ItemForSpawn;
    public float RotationSpeed;

    private GameObject _instance;

    private bool isTake = false;

    private ItemTypes _itemType;

    private Player _player;

    void Start()
    {
        _instance = Instantiate(ItemForSpawn.Prefub, transform.position, Quaternion.identity);

        _itemType = ItemForSpawn.Type;
        if (_itemType == ItemTypes.Weapon)
        {
            _instance.transform.SetParent(transform);
        }

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
            _player = other.gameObject.GetComponent<Player>();

            isTake = true;
            if (_itemType == ItemTypes.Weapon)
            {
                var gunInfo = (Firearms)ItemForSpawn.Description;
                if (PlayerHotBar.FirstSlot == null && gunInfo.WeaponTypes == WeaponTypes.Main)
                {
                    PlayerHotBar.FirstSlot = ItemForSpawn;
                    DestroyInstance();
                    return;
                }
                else if (PlayerHotBar.SecondSlot == null && gunInfo.WeaponTypes == WeaponTypes.Second)
                {
                    PlayerHotBar.SecondSlot = ItemForSpawn;
                    DestroyInstance();
                    return;
                }else
                {
                    AddToInventory();
                }
            }
        }
    }

    private void AddToInventory()
    {
        PlayerInventorty.Add(ItemForSpawn);
        DestroyInstance();
    }
    private void DestroyInstance()
    {
        _instance.transform.SetParent(null);
        Destroy(_instance);
         Destroy(transform.parent.gameObject);
        Destroy(gameObject);
       
    }
}
