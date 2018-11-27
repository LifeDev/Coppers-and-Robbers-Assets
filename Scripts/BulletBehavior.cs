using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public float velocityX = 10f;
    private float velocityY = 0f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

   
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(velocityX, velocityY);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        Destroy(gameObject);
    }
}
    