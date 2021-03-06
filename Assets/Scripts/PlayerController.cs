﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
#if UNITY_STANDALONE || UNITY_EDITOR

    private MovementComponent movementComponent;

    void Awake()
    {
        //Retrieve reference to the Movement Component
        movementComponent = GetComponent<MovementComponent>();

        //Disable this script in case the Movement Component is not found, 
        // and leave an error message.
        if (movementComponent == null)
        {
            Debug.LogError("Missing MovementComponent on " + gameObject.name + " to run PlayerController. Please add one.");
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        //Send input to the Movement Component in order to move the character
        movementComponent.MoveCharacter(Input.GetAxis("Horizontal") * 10000.0f);

        //Check if the Up Arrow has been pressed, and if so, 
        // send the Jump input to the Movement Component
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movementComponent.Jump();
        }
    }

#endif
}
