using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeerMovement : MonoBehaviour {

 
    public GameObject player;
    public GameObject entity;

    ElevatorController elevator = new ElevatorController();

    public float movementSpeed = 40f;
    float horizontalMove;
    float verticalMove;

    public bool elevatorChecked { get; set; }

    private void Start()
    {
        elevatorChecked = false;

    }

    // Update is called once per frame
    void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        transform.position =  new Vector2(transform.position.x + horizontalMove, transform.position.y);

        if (elevatorChecked)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                elevator.Elevate(player);
                elevatorChecked = false;
            }
        }


    }

    
}
