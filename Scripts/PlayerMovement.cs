using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerMovement : CharacterMovement {

 
    public GameObject player;
    

    ElevatorController elevator = new ElevatorController();

    public float movementSpeed;
    
    public SpriteRenderer rend;

    public bool canSprint { get; set; }

    private float sprintCooldownTemp;
    public float sprintCooldown;
    private float sprintDurationTemp;
    public float sprintDuration;
    
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        playerElevatorChecked = false;
        insideBuilding = false;
        canEnterBuilding = false;
        canSprint = true;
        sprintCooldownTemp = sprintCooldown;
        sprintDurationTemp = sprintDuration;
        FirstLevel = true;
    }

    // Update is called once per frame
        void Update()
        {
        //movement
            MoveRobber(movementSpeed, playerElevatorChecked, insideBuilding, canEnterBuilding, rend);
            
            Sprint();
        }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canSprint)
            {
                movementSpeed *= 2f;
                canSprint = false;
                sprintDurationTemp -= 0.000001f;
            }
        }

        if (!canSprint)
        {
            if (!(sprintDurationTemp == sprintDuration))
            {
                sprintDurationTemp -= Time.deltaTime;

            }
            sprintCooldownTemp -= Time.deltaTime;
            Debug.Log(sprintCooldown);
            Debug.Log(sprintDuration);
        }

        if (sprintCooldownTemp <= 0f)
        {
            canSprint = true;
            sprintCooldownTemp = sprintCooldown;
        }

        if (sprintDurationTemp <= 0f)
        {
            movementSpeed = movementSpeed / 2f;
            sprintDurationTemp = sprintDuration;
            
        }
        
    }

    }
