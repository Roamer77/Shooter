using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonActions : MonoBehaviour
{
    public GameObject Player;

    private RollMovement _rollMovement;
    void Start()
    {
       _rollMovement = Player.GetComponent<RollMovement>();
    }
    public void SitDown()
    {
        Debug.Log("SitDown");
    }

    public void ExternalMovemet()
    {
        _rollMovement.Roll();
    }
}
