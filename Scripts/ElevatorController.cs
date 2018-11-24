using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

    int blocksToTp = 9;
 
  
    public PlayeerMovement player;
    public EntityController entity;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.elevatorChecked = true;
        }
        else if (collision.gameObject.tag == "Entity") {  
            if (EntityController.useElevator())
                Elevate(collision.gameObject);
        }
    }

   void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.elevatorChecked = false;
        }
    }

    public void Elevate(GameObject character)
    {
        character.transform.position = new Vector2(character.transform.position.x, character.transform.position.y + blocksToTp);
    }


}
