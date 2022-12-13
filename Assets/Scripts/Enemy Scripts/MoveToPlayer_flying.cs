using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer_flying : MoveToPlayer
{
    public Rigidbody rb;
    public override void RayCastHitAction(RaycastHit hit)
    {
        rb.velocity = transform.forward * _moveSpeed;
    }
    private void FixedUpdate()
    {
        transform.LookAt(_final_position);
    }
}
