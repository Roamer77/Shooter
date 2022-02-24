using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonActions : MonoBehaviour
{
    public GameObject Player;

    private RollMovement _rollMovement;
    private Gun _gun;
    void Start()
    {
       _rollMovement = Player.GetComponent<RollMovement>();
       _gun = Player.GetComponentInChildren<Gun>();
    }
    public void SitDown()
    {
        _gun.MakeDamege();
       //Debug.Log("SitDown");
    }

    public void ExternalMovemet()
    {
        _rollMovement.Roll();
    }
}
