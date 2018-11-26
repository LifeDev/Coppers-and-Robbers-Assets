using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EntityMovement : CharacterMovement {

    //target to what position go to
    private Vector2 target;


    private void Start()
    {
        ElevatorChecked = false;
        target = Spawner.getPoint();
    }

    void Update ()
	{
        MoveNPC(movementSpeed, gameObject.GetComponent<EntityMovement>(), target, gameObject);
	}
}
