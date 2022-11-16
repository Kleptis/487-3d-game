using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    //public Rigidbody rb;
    [SerializeField] GameObject gameobj;
    Rigidbody rb;
    [SerializeField] private Vector3 PlayerMoveInput;
    [SerializeField] private float moveSpeed;
    public bool canMove;
    void Start()
    {
        rb = gameobj.GetComponent<Rigidbody>();
        canMove = false;
        PlayerMoveInput = new Vector3();
    }

    // Update is called once per frame
    private void FixedUpdate()//movement
    {
        rb.velocity = new Vector3(PlayerMoveInput.x * moveSpeed, PlayerMoveInput.y * moveSpeed, PlayerMoveInput.z * moveSpeed);
    }
}
