using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Events")]
    public GameEvent onPlayerInteract;
    public GameEvent onPause;
    public GameEvent on_l_click;

    public float moveSpeed = 5f;
    public Rigidbody rb;
    public Kanji_shmup playerControls;

    public Vector3 PlayerMoveInput;
    public Vector2 MouseMoveInput;
    private InputAction move;
    private InputAction upDown;
    private InputAction mouseDelta;
    private InputAction fire;
    private InputAction ui_l_click;
    private InputAction ui_r_click;
    private InputAction esc;

    private void Awake()
    {
        playerControls = new Kanji_shmup();
    }
    void Start()
    {
        playerControls.Enable();

    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        move.performed += ctx =>
        {
            PlayerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, PlayerMoveInput.y, ctx.ReadValue<Vector2>().y);
        };
        move.canceled += ctx =>
        {
            PlayerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, PlayerMoveInput.y, ctx.ReadValue<Vector2>().y);
        };

        upDown = playerControls.Player.UpDown;
        upDown.Enable();
        upDown.performed += ctx =>
        {
            PlayerMoveInput = new Vector3(PlayerMoveInput.x, ctx.ReadValue<float>(), PlayerMoveInput.z);
        };
        upDown.canceled += ctx =>
        {
            PlayerMoveInput = new Vector3(PlayerMoveInput.x, ctx.ReadValue<float>(), PlayerMoveInput.z);
        };

        mouseDelta = playerControls.Player.MouseDelta;
        mouseDelta.Enable();
        mouseDelta.performed += ctx =>
        {
            MouseMoveInput = ctx.ReadValue<Vector2>();
        };
        mouseDelta.canceled += ctx =>
        {
            MouseMoveInput = ctx.ReadValue<Vector2>();
        };

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Interact;

        esc = playerControls.UI.Cancel;
        esc.Enable();
        esc.performed += Pause;

        
        ui_l_click = playerControls.UI.Click;
        ui_l_click.Enable();
        ui_l_click.performed += l_click;

        ui_r_click = playerControls.UI.Click;
        ui_r_click.Enable();
        
        
        
    }
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        ui_l_click.Disable();
        ui_r_click.Disable();
        esc.Disable();
    }


    private void FixedUpdate()//movement
    {
        rb.velocity = new Vector3(PlayerMoveInput.x * moveSpeed, PlayerMoveInput.y * moveSpeed, PlayerMoveInput.z * moveSpeed);
    }

    private void Interact(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValueAs);
        onPlayerInteract.Raise(this, context.ReadValueAsButton());

    }

    private void Pause(InputAction.CallbackContext context)
    {
        onPause.Raise();
    }
    private void l_click(InputAction.CallbackContext context)
    {
        string d;
        if (context.ReadValueAsButton().Equals(true))
            d = "pressed";
        else
            d = "released";
        //Debug.Log("Left Click " + d);
        on_l_click.Raise(this, context);
    }
}
