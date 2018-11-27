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



    public GameObject bulletLeft , bulletRight;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    void Shoot() { 
     if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
            {
            nextFire = Time.time + fireRate;
            PosToFire();
            }
    }

    void PosToFire()
    {
        bulletPos = transform.position;
        if (!rend.flipX)
        {
            bulletPos += new Vector2(+0.35f, +0.3f);
            Instantiate(bulletRight, bulletPos, Quaternion.identity);
        }
        if (rend.flipX)
        {
            bulletPos += new Vector2(-0.35f, +0.3f);
            Instantiate(bulletLeft, bulletPos, Quaternion.identity);
        }

    }



    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        Shoot();
            Sprint();
            
            Running();
            
            
        }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.Z))
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

    void Running()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed * 2;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed / 2;
        }
    }

    }
