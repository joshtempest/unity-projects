using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    private Vector2 movement; // Vi vil gemme det "Vector2" der kommer ind n�r man trykker WSAD ind p� movement
    private Rigidbody2D myBody; // Den rigidbody vi vil flytte rundt
    public FoodManager foodManager;
    public PickUp pickUp;
    public Animator myAnimator;

   

    [SerializeField] private int speed = 5; //Den hastighed vores human skal flyttes rundt

    private void Awake() // Awake k�re kun engang n�r programmet starter
    {
        myBody = GetComponent<Rigidbody2D>(); // Vi s�tter myBody rigidbody til rigidbody p� det gameobject vi sidder p�
    }
    private void OnMovement(InputValue value) // Vi laver en function der holder �je med vores Input systems value
    {
        movement = value.Get<Vector2>(); // Movement bliver sat til vector 2 fra vores Input Action n�r brugeren trykker WSAD

        if (movement.x != 0 || movement.y !=0)
        {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);

            myAnimator.SetBool("isWalking", true);
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate() // FixedUpdate er mere effektiv end update n�r det kommer til even based ting som flytning
    {
        myBody.velocity = movement * speed; // Vi s�tter vores velocity af vores rigidbody2D i den hastighed vi har sat
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            foodManager.Actions();
            print("space key was pressed");
        }
    }

}
