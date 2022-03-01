using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int _health = 3;

    public void Damege(int amount)
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
        _health -= amount;
    }

}
