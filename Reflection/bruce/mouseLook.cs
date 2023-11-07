using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // This holds our instance of our control scheme, CharacterInput refers to the name we gave

    // to our "controls" name that we made earlier

    private CharacterInput controls;



    public float mouseSensitivity = 100f; // Allows us to change the sensitivity

    private Vector2 mouseLook; // Holds where we are looking

    private float xRotation = 0f; // This is us rotating around the x axis



    public Transform playerBody; // Holds the player character
    // Start is called before the first frame update
    void Start()
    {
        
    }

        void Awake()
        {
            controls = new CharacterInput();
        }
         void Update()
        {
            mouseLook = controls.Player.Look.ReadValue<Vector2>();

            float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
            float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            playerBody.Rotate(Vector3.up * mouseX);
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
