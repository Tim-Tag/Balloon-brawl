using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//New
using UnityEngine.InputSystem;

public class gunSwitcher : MonoBehaviour
{
    public List<GameObject> guns;
    private CharacterInput controls;
    private int current = 0;

    void Awake()
    {
        controls = new CharacterInput();

        for (int i = 0; i < guns.Count; i++)
        {
            guns[i].SetActive(false);
        }
        guns[current].SetActive(true);
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
        float direction = controls.Player.WeaponChange.ReadValue<float>();

        if (direction != 0)
        {
            changeWeapon(direction);
        }
    }

    void changeWeapon(float direction)
    {
        guns[current].SetActive(false);
        if (direction > 0)
        {
            if (current > 0)
            {
                current -= 1;
            }
            else
            {
                current = guns.Count - 1;
            }
        }
        else if (direction < 0)
        {
            if (current < guns.Count - 1)
            {
                current += 1;
            }
            else
            {
                current = 0;
            }
        }
        guns[current].SetActive(true);

    }
}
