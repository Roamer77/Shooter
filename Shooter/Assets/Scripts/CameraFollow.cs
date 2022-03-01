using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 CameraOffset;

    public Transform Target;

    private float _smoothSpeed = 10f;

    void FixedUpdate()
    {
        var desiredPosition = Target.position + CameraOffset;
        var smoothPostion = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.position = smoothPostion;

        transform.LookAt(Target);
    }
}
