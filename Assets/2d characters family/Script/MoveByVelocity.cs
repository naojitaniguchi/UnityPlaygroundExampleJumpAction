﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveByVelocity : MonoBehaviour
{
    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 5f;
    public Enums.MovementType movementType = Enums.MovementType.AllDirections;

    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that will face the player
    public Enums.Directions lookAxis = Enums.Directions.Up;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;


    // Update gets called every frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }

        //zero-out the axes that are not needed, if the movement is constrained
        switch (movementType)
        {
            case Enums.MovementType.OnlyHorizontal:
                moveVertical = 0f;
                break;
            case Enums.MovementType.OnlyVertical:
                moveHorizontal = 0f;
                break;
        }

        movement = new Vector2(moveHorizontal, moveVertical);


        //rotate the GameObject towards the direction of movement
        //the axis to look can be decided with the "axis" variable
        if (orientToDirection)
        {
            if (movement.sqrMagnitude >= 0.01f)
            {
                cachedDirection = movement;
            }
            Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
        }
    }



    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        // Apply the force to the Rigidbody2d
        // GetComponent<Rigidbody2D>().AddForce(movement * speed * 10f);
        GetComponent<Rigidbody2D>().velocity = movement * speed ;
    }
}
