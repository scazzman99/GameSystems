using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Player player;
    private int weaponIndex = 0;

    private void Start()
    {
        player.SelectWeapon(weaponIndex);
    }


    // Update is called once per frame
    void Update () {

        WeaponSwitch();

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        player.Move(inputH, inputV);

        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            player.Attack();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            player.Interact();
        }
	}

    void WeaponSwitch()
    {

        int currentIndex = weaponIndex;


        //if Q is pressed swap to previous weapon if weaponIndex > 0
        //decrement index
        //vice versa for E press
        if(Input.GetKeyDown(KeyCode.Q) && weaponIndex > 0)
        {
            currentIndex--;
        }
        if (Input.GetKeyDown(KeyCode.E) && weaponIndex < player.weapons.Length)
        {
            currentIndex++;
        }

        if (currentIndex != weaponIndex)
        {
            weaponIndex = currentIndex;
            player.SelectWeapon(weaponIndex);
        }
    }
}
