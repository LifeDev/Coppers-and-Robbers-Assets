using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public GameObject player;

    ElevatorController elevator = new ElevatorController();

    public float movementSpeed = 40f;
    float horizontalMove;
    float verticalMove;

    public bool elevatorChecked { get; set; }

    public bool canEnterBuilding { get; set; }

    public bool insideBuilding { get; set; }

    public SpriteRenderer rend;

    public float timeInsideBuilding = 2f;
    
    public float currentTimeInsideBuilding;
    
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        elevatorChecked = false;
        canEnterBuilding = false;
        insideBuilding = false;
    }

    // Update is called once per frame
    void Update () {
        if (!insideBuilding)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
            transform.position =  new Vector2(transform.position.x + horizontalMove, transform.position.y);
        }
        

        if (elevatorChecked)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                elevator.Elevate(player);
                elevatorChecked = false;
            }
        }

        if (insideBuilding)
        {
            
            currentTimeInsideBuilding -= Time.deltaTime;
            Debug.Log(currentTimeInsideBuilding);
            if (currentTimeInsideBuilding < 0)
            {
                rend.sortingLayerName = "Character";
                insideBuilding = false; 
            }
        }
        if (canEnterBuilding)
        {
            
            if (Input.GetKeyDown(KeyCode.W) && !insideBuilding)
            {
                currentTimeInsideBuilding = timeInsideBuilding;
                rend.sortingLayerName = "Background";
                insideBuilding = true;
                
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                
                rend.sortingLayerName = "Character";
                insideBuilding = false;
            }
            
        }

    }
}
