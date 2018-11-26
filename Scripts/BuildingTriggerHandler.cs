using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingTriggerHandler : MonoBehaviour
{


	[FormerlySerializedAs("player")] public RobberMovement Robber;
	    
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Robber.canEnterBuilding = true;
        
		}
        else if (collision.gameObject.tag == "Entity")
        {

        }
	
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Robber.canEnterBuilding = false;
		}
	}
}
