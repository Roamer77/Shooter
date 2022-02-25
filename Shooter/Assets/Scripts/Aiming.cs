using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Vector3 _input;
    public Ray Ray;
    private LineRenderer AimLine;

    [HideInInspector]
    public bool isAming = false;

    public Transform Player;

    void Start()
    {
        AimLine = GetComponent<LineRenderer>();
        AimLine.enabled = isAming;
    }
    void Update()
    {
        AimLine.enabled = isAming;
        AimLine.transform.rotation = Player.transform.rotation;
    }

    public void Aim(Quaternion playerRotation, float aimDistance)
    {
        AimLine.SetPosition(0, Player.position);
        AimLine.SetPosition(1, Player.position + (Player.forward * aimDistance));
    }
}
