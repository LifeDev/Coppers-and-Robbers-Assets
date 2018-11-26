using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EntityMovement : CharacterMovement {

    public float speed = 5f;
    //target to what position go to
    private Vector2 target;


    private void Start()
    {
        entityElevatorChecked = false;
        target = EntityController.getPoint();
    }

    void Update ()
	{
        MoveNPC(speed, this, target, gameObject);
	}
}
