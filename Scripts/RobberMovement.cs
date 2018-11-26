using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;

public class RobberMovement : CharacterMovement {

    
    

    public bool canSprint { get; set; }

    private float sprintCooldownTemp;
    public float sprintCooldown;
    private float sprintDurationTemp;
    public float sprintDuration;
    public UnityEngine.UI.Image cooldownImage;
    private float cooldownImageHeight;
    
    private void Start()
    {
        
        rend = GetComponent<SpriteRenderer>();
        ElevatorChecked = false;
        insideBuilding = false;
        canEnterBuilding = false;
        canSprint = true;
        sprintCooldownTemp = sprintCooldown;
        sprintDurationTemp = sprintDuration;

        cooldownImage.enabled = false;
        cooldownImageHeight = cooldownImage.rectTransform.sizeDelta.y;

        FirstLevel = true;

    }

    // Update is called once per frame
        void Update()
        {
        //movement
            MoveRobber(movementSpeed, ElevatorChecked, insideBuilding, canEnterBuilding, rend);
            
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
                cooldownImage.enabled = true;
                cooldownImage.color = new Color32(102,204,102,180);

            }
        }

        if (!canSprint)
        {
            if (!(sprintDurationTemp == sprintDuration))
            {
                sprintDurationTemp -= Time.deltaTime;

            }
            sprintCooldownTemp -= Time.deltaTime;
            cooldownImage.rectTransform.sizeDelta = new Vector2(100, cooldownImage.rectTransform.sizeDelta.y - Time.deltaTime * (cooldownImageHeight / sprintCooldown));
            Debug.Log(sprintCooldown);
            Debug.Log(sprintDuration);
        }

        if (sprintCooldownTemp <= 0f)
        {
            canSprint = true;
            sprintCooldownTemp = sprintCooldown;
            cooldownImage.enabled = false;
            cooldownImage.rectTransform.sizeDelta = new Vector2(100, 100);
        }

        if (sprintDurationTemp <= 0f)
        {
            movementSpeed = movementSpeed / 2f;
            sprintDurationTemp = sprintDuration;
            cooldownImage.color = new Color32(108,108,108,180);
        }
        
    }

    }
