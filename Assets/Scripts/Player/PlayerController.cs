using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    [Header("Events")]
    public GameEvent onPlayerInteract;
    public GameEvent onPause;
    //public GameEvent on_l_click;

    //[Header("Auxilliary Scripts")]
    //[SerializeField] PlayerMovement playermovement;
    //[SerializeField] MouseLook mouseLook;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 8f;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {

            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        if (inputManager.PlayerPaused())
            onPause.Raise();
        if (inputManager.PlayerShotThisFrame())
            onPlayerInteract.Raise();


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    //// Start is called before the first frame update
    //[Header("Events")]
    //public GameEvent onPlayerInteract;
    //public GameEvent onPause;
    //public GameEvent on_l_click;

    //[Header("Auxilliary Scripts")]
    //[SerializeField] PlayerMovement playermovement;
    //[SerializeField] MouseLook mouseLook;

    //public Kanji_shmup playerControls;

    //private Vector2 PlayerMoveInput;
    //private Vector2 MouseInput;
    //private InputAction move;
    //private InputAction mouseDelta;
    //private InputAction fire;
    //private InputAction ui_l_click;
    //private InputAction ui_r_click;
    //private InputAction esc;
    ////private InputAction upDown;

    //private void Awake()
    //{
    //    playerControls = new Kanji_shmup();//Auto-generated C# class for player controller
    //}
    //void Start()
    //{
    //    playerControls.Enable();

    //}
    //private void OnEnable()
    //{
    //    move = playerControls.Player.Move;
    //    move.Enable();
    //    move.performed += ctx =>
    //    {
    //        //PlayerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, PlayerMoveInput.y, ctx.ReadValue<Vector2>().y);
    //        PlayerMoveInput = new Vector2(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y);
    //        //_PlayerMoveInput = new Vector2(ctx.ReadValue<Vector2>().x, _PlayerMoveInput.y);

    //    };
    //    move.canceled += ctx =>
    //    {
    //        //PlayerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, PlayerMoveInput.y, ctx.ReadValue<Vector2>().y);
    //        PlayerMoveInput = new Vector2(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y);
    //        //_PlayerMoveInput = new Vector2(ctx.ReadValue<Vector2>().x, _PlayerMoveInput.y);
    //    };

    //    //upDown = playerControls.Player.UpDown;
    //    //upDown.Enable();
    //    //upDown.performed += ctx =>
    //    //{
    //    //    PlayerMoveInput = new Vector3(PlayerMoveInput.x, ctx.ReadValue<float>(), PlayerMoveInput.z);
    //    //};
    //    //upDown.canceled += ctx =>
    //    //{
    //    //    PlayerMoveInput = new Vector3(PlayerMoveInput.x, ctx.ReadValue<float>(), PlayerMoveInput.z);
    //    //};

    //    mouseDelta = playerControls.Player.MouseDelta;
    //    mouseDelta.Enable();
    //    mouseDelta.performed += ctx => MouseInput = ctx.ReadValue<Vector2>();
    //    mouseDelta.canceled += ctx =>
    //    {
    //        MouseInput = ctx.ReadValue<Vector2>();
    //    };

    //    fire = playerControls.Player.Fire;
    //    fire.Enable();
    //    fire.performed += Interact;
    //    //fire.performed += ctx => playermovement.OnJumpPressed(ctx);

    //    esc = playerControls.UI.Cancel;
    //    esc.Enable();
    //    esc.performed += Pause;


    //    ui_l_click = playerControls.UI.Click;
    //    ui_l_click.Enable();
    //    ui_l_click.performed += l_click;

    //    ui_r_click = playerControls.UI.Click;
    //    ui_r_click.Enable();



    //}
    //private void OnDisable()
    //{
    //    move.Disable();
    //    fire.Disable();
    //    ui_l_click.Disable();
    //    ui_r_click.Disable();
    //    esc.Disable();
    //}

    //private void Update()
    //{
    //    mouseLook.ReceiveInput(MouseInput);
    //}

    //private void FixedUpdate()//movement
    //{
    //    playermovement.RecieveInput(PlayerMoveInput);
    //}

    //private void Interact(InputAction.CallbackContext context)
    //{
    //    onPlayerInteract.Raise(this, context.ReadValueAsButton());
    //    playermovement.OnJumpPressed();

    //}

    //private void Pause(InputAction.CallbackContext context)
    //{
    //    onPause.Raise();
    //}
    //private void l_click(InputAction.CallbackContext context)
    //{
    //    string d;
    //    if (context.ReadValueAsButton().Equals(true))
    //        d = "pressed";
    //    else
    //        d = "released";
    //    //Debug.Log("Left Click " + d);
    //    on_l_click.Raise(this, context);
    //}
}
