using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEnter : MonoBehaviour
{


	public PlayerMovement player;
	    
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			player.canEnterBuilding = true;
        
		}
	
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			player.canEnterBuilding = false;
		}
	}
}
