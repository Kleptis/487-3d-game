using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MoveToPlayer : MonoBehaviour
{
    [SerializeField] GameObject gameobject;
    private Vector3 final_position;
    public Vector3 _final_position { get { return final_position; } set { final_position = value; }}
    private Vector3 initial_position;
    //public Vector3 _initial_position { get { return initial_position; } set { initial_position = value; } }
    private Vector3 direction;
    public Vector3 _direction { get { return direction; } set { direction = value; } }

    [SerializeField] private float moveSpeed;
    public float _moveSpeed { get { return moveSpeed; } }
    
    public bool canMove;
    Ray ray;

    void Start()
    {
        canMove = false;
        final_position = new Vector3();
        initial_position = new Vector3();
        direction = new Vector3();                                       
        //Physics.Raycast(V3 origin, V3 direction, RaycastHit hitInfo,
        //(optional) float distance, (optional) int LayerMask);
        
    }
    public void Listener(Component sender, object data)
    {
        final_position = (Vector3)data;
        direction = (final_position - transform.position);
        direction.Normalize();
        direction *= moveSpeed;
        RaycastHit hit;
        ray = new Ray(initial_position, direction);
        if(Physics.Raycast(ray,out hit))
        {
            RayCastHitAction(hit);
        }
        //rb.velocity = direction;
    }
    //Physics.Raycast(V3 origin, V3 direction, RaycastHit hitInfo,
    //(optional) float distance, (optional) int LayerMask);
    public abstract void RayCastHitAction(RaycastHit hit);

    
} 

