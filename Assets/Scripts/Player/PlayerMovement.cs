using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//jump buffer
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] CharacterController controller;
    [SerializeField] float jumpHeight = 3.5f;
    bool jump;
    [SerializeField] float gravity = -30f;
    [SerializeField] float thiccness = 0.1f;
    Vector3 vertVelocity = Vector3.zero;
    //[SerializeField] Rigidbody rb;
    Vector2 moveInput;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    private void Start()
    {
        Debug.Log("jump:" + jump);
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
        //isGrounded = Physics.CheckSphere(transform.position, thiccness, groundMask);//casts an invisible sphere at the location of our player
        //Debug.Log(Physics.CheckSphere(transform.position, 0.1f,groundMask));
        //T if intersects an object with a ground layer, else F
        if (isGrounded)
        {
            vertVelocity.y = 0;
            //Debug.Log("isGrounded: " + isGrounded);
        }
        Vector3 horizontalVel = (transform.right * moveInput.x + transform.forward * moveInput.y) * moveSpeed;
        controller.Move(horizontalVel * Time.deltaTime);//willgive us constant movement speed regardless of frame rate
        //Jump: v = sqrt(-1 * jumpHeight * gravity)
        if (jump)
        {
            if (isGrounded)
            {
                vertVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }
            
        
        vertVelocity.y += gravity * Time.deltaTime;
        controller.Move(vertVelocity * Time.deltaTime);
    }

    public void RecieveInput(Vector2 _moveInput)
    {
        moveInput = _moveInput;
        //Debug.Log(moveInput);
        //rb.velocity = new Vector3(_moveInput.x * moveSpeed,0, _moveInput.y * moveSpeed);
    }
    //public void OnJumpPressed(InputAction.CallbackContext context)
    public void OnJumpPressed()
    {
        //Debug.Log("was pressed");
        jump = true;
        //Debug.Log("jump:" + jump);
    }
}
