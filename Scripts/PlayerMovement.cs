using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;

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
    public Text cooldownText;
    public UnityEngine.UI.Image cooldownImage;
    private float cooldownImageHeight;
    
    private void Start()
    {
        
        rend = GetComponent<SpriteRenderer>();
        playerElevatorChecked = false;
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
            //cooldownText.text = Mathf.Ceil(sprintCooldownTemp).ToString();
            cooldownImage.rectTransform.sizeDelta = new Vector2(100, cooldownImage.rectTransform.sizeDelta.y - Time.deltaTime * (cooldownImageHeight / sprintCooldown));
            Debug.Log(sprintCooldown);
            Debug.Log(sprintDuration);
        }

        if (sprintCooldownTemp <= 0f)
        {
            canSprint = true;
            sprintCooldownTemp = sprintCooldown;
            cooldownImage.enabled = false;
            //cooldownText.text = "";
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
