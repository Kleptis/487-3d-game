using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] GameObject gameobject;
    Rigidbody rb;
    private Vector3 final_position;
    private Vector3 initial_position;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;
    public bool canMove;

    public NavMeshAgent agent;
    Ray ray;
    void Start()
    {
        rb = gameobject.GetComponent<Rigidbody>();
        canMove = false;
        final_position = new Vector3();
        initial_position = new Vector3();
        direction = new Vector3();
        //Physics.Raycast(V3 origin, V3 direction, RaycastHit hitInfo,
        //(optional) float distance, (optional) int LayerMask);
        
    }
    private void FixedUpdate()
    {
        initial_position = new Vector3 (rb.position.x, rb.position.y, rb.position.z);
    }


    // Update is called once per frame
    //private void MoveGameObject()
    //{
    //    rb.velocity = new Vector3(final_position.x * moveSpeed, final_position.y * moveSpeed, final_position.z * moveSpeed);
    //}
    public void Listener(Component sender, object data)
    {
        final_position = (Vector3)data;
        direction = (final_position - initial_position);
        direction.Normalize();
        direction *= moveSpeed;
        RaycastHit hit;
        ray = new Ray(initial_position, direction);
        if(Physics.Raycast(ray,out hit))
        {
            agent.SetDestination(hit.point);
        }
        //rb.velocity = direction;
    }
    //Physics.Raycast(V3 origin, V3 direction, RaycastHit hitInfo,
        //(optional) float distance, (optional) int LayerMask);
      
} 
