using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer_grounded : MoveToPlayer
{
    public NavMeshAgent agent;
    public override void RayCastHitAction(RaycastHit hit)
    {
        agent.SetDestination(hit.point);
    }

}
