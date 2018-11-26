using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ElevatorTriggerHandler : MonoBehaviour {

    float blocksToTp = Spawner.secondLevel - Spawner.firstLevel;

    [FormerlySerializedAs("player")] public RobberMovement Robber;
    public EntityMovement entity;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Robber.ElevatorChecked = true;
            Debug.Log(Robber.ElevatorChecked);
        }
        else if (collision.gameObject.tag == "Entity")
        {
            entity = collision.GetComponent<EntityMovement>();
            entity.ElevatorChecked = true;
            Debug.Log(entity.ElevatorChecked);
        }
    }

   void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Robber.ElevatorChecked = false;
        }
        if (collision.gameObject.tag == "Entity")
        {
            entity = collision.GetComponent<EntityMovement>();
            entity.ElevatorChecked = false;
        }
    }

    public void Elevate(GameObject character)
    {
        character.transform.position = new Vector2(character.transform.position.x, character.transform.position.y + blocksToTp);
    }

    public void Elevate(EntityMovement character)
    {
        character.transform.position = new Vector2(character.transform.position.x, character.transform.position.y + blocksToTp);
    }

    public void Lower(GameObject character)
    {
        character.transform.position = new Vector2(character.transform.position.x, character.transform.position.y - blocksToTp);
    }

    public void Lower(EntityMovement character)
    {
        character.transform.position = new Vector2(character.transform.position.x, character.transform.position.y - blocksToTp);
    }
}
