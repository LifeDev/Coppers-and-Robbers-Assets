using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour {

    public float speed = 5f;
    //target to what position go to
    private Vector2 target = new Vector2(80, 3);

	void Update () {
        float movement = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position , target, movement);
    }
}
