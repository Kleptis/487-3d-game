using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastPosition : MonoBehaviour
{
    // Start is called before the first frame updat    // Start is called before the first frame update
    //public Rigidbody rb;
    [SerializeField] GameObject gameobj;
    [SerializeField] GameEvent gameEvent;
    Rigidbody rb;
    private bool canBroadcast;
    private Vector3 coordinates;
    private void Start()
    {
        rb = gameobj.GetComponent<Rigidbody>();
        canBroadcast = false;
        coordinates = new Vector3();
    }

    // Update is called once per frame
    private void FixedUpdate()//movement
    {
        if (canBroadcast == false)
            return;
        else
        {
            coordinates = new Vector3(rb.position.x, rb.position.y, rb.position.z);
            gameEvent.Raise(this, coordinates);
        }
    }
    public void broadcastPos(Component sender, object data)
    {
        if ((int)data < 0)
            canBroadcast = true;
    }
}
