using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollMovement : MonoBehaviour
{
    public Rigidbody TargetRB;
    public float Speed;
    public float DashTime;
    public void Roll()
    {
      StartCoroutine(RollMove());
    }

    IEnumerator RollMove()
    {
        var startTime = Time.time;
        while (Time.time < startTime + DashTime)
        {
            TargetRB.MovePosition(transform.position + (transform.forward  ) * Speed * Time.deltaTime);
            yield return null;
        }
    }
}
