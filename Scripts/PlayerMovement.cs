using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerMovement : CharacterMovement {

 
    public GameObject player;
    

    ElevatorController elevator = new ElevatorController();

    public float movementSpeed;
    
    public SpriteRenderer rend;


    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        elevatorChecked = false;
        insideBuilding = false;
        canEnterBuilding = false;
    }

    // Update is called once per frame
        void Update()
        {
        //movement
            MoveRobber(movementSpeed, elevatorChecked, insideBuilding, canEnterBuilding, rend);
            

    }

    }
