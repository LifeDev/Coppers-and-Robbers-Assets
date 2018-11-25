using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EntityMovement : CharacterMovement {

    public float speed = 5f;
    //target to what position go to
    private Vector2 target = new Vector2(80, 3);

	void Update ()
	{
	    MoveNPC(speed, gameObject);
	}
}
