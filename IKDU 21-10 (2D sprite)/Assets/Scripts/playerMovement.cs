using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Vector2 movement; //We save the Vector2 movement from WASD input
    private Rigidbody2D myBody; //The rigidbody of the character that needs to move
    private Animator myAnimator; //Animator variable, to tamper with in code

    [SerializeField] private int speed = 5; //Variable of velocity of which the character should move around with

    private void Awake() //Awake runs once at start of program
    {
        myBody = GetComponent<Rigidbody2D>(); //Rigidbody variable now defined as the one on the gameofbject the script is on
        myAnimator = GetComponent<Animator>(); //To tamper with the animator of the gameobject the script is on
    }

    private void OnMovement(InputValue value) //A function that receives values from the input system
    {
        movement = value.Get<Vector2>(); //Movement is set to vector2 from the Input Action on WASD press

        if (movement.x != 0 || movement.y != 0) // Makes sure no movement is done if no input is given
        {
            myAnimator.SetFloat("x", movement.x);//Changes x in the animator to the movement.x from unity input
            myAnimator.SetFloat("y", movement.y);//Changes y in the animator to the movement.y from unity input
            myAnimator.SetBool("IsWalking", true); //When either value isn't 0, we are walking
        }
        else
        {
            myAnimator.SetBool("IsWalking", false); //Since both values are 0, we aren't walking
        }
    }

    private void FixedUpdate() //More effective to use fixedupdate rather than update for event based happenings
    {
        myBody.velocity = movement * speed; //The velocity of the rigidbody is changed
    } 
}
