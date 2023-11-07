using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    private CharacterInput controls;

    public float damage = 10f; // How much damage our gun causes

	public float range = 100f; // How far we can shoot



	public Camera fpsCam;

    void Awake()
    {
        controls = new CharacterInput();

        if (fpsCam == null)
        {
            fpsCam = transform.parent.gameObject.GetComponent<Camera>();
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

    // Update is called once per frame
    void Update()
    {
        // Check our controller to see if we have pressed the fire button
        if (controls.Player.shoot.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Define a raycast hit object
        RaycastHit hit;

        //Shoot the ray from the camera's position and rotation for the distance in the range
        // this will return a true / false value and the object info of what we hit in "hit"
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // if we hit something, print it to the debug log
            Debug.Log(hit.transform.name);

            // Grab the game object we hit and see if there is a target script component on it
            target enemy = hit.transform.GetComponent<target>();

            // If the target script exists, call the function in the target script to cause damage
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
