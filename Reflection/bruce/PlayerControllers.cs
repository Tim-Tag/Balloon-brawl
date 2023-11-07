using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterInput controls; // Our controls we defined

    private Vector3 velocity; // To hold our current velocity

    private Vector2 move; // To hold our move





    private CharacterController controller; // Character controller



    public float defaultSpeed = 6f; // To calibrate our movement

    public float jumpHeight = 2.4f; // To calibrate our jump

    public float gravity = -9.81f; // To calibrate our gravity
    public float sprintSpeed = 3f;
    float moveSpeed;

    bool sprintCheck = false;

    public Transform ground; // Ground check empty goes in here

    public float distanceToGround = 0.4f; // How close the ground needs to be to register
    //public float distanceToGround = 0f; // How close the ground needs to be to register

    public LayerMask groundMask; // What layer is ground?

    void Awake()

    {
        moveSpeed = defaultSpeed;
        controls = new CharacterInput();

        controller = GetComponent<CharacterController>();
    }



    void Update()

    {
        PlayerMovement();
        Grav();
        Jump();
    }



    private void Grav()

    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }



    private bool isGrounded()

    {
        return Physics.CheckSphere(ground.position, distanceToGround, groundMask);
    }



    private void PlayerMovement()

    {
        

            move = controls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);

        //var isStillActuated = controls.Player.sprint.ControlIsActuated(0.75f);

        
        // Below returns 1 if key is pressed, 0 if not so we add sprint speed if it is pressed
        if (controls.Player.sprint.ReadValue<float>() > 0.1 && sprintCheck == false)
        {
            moveSpeed += sprintSpeed;
            sprintCheck = true;
        }
        else if(controls.Player.sprint.ReadValue<float>() == 0)
        {
            sprintCheck = false;
            moveSpeed = defaultSpeed;
        }
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }



    private void Jump()

    {
        if (controls.Player.Jump.triggered && isGrounded())

        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }



    void OnEnable()

    {
        controls.Enable();
    }



    void OnDisable()

    {
        controls.Disable();
    }
}
