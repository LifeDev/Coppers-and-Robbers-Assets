using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    static public int entityExists = 0;
    static public float entityQuantity = 20;
    public GameObject entity;

    public static float firstLevel = -3.311636f;
    public static float secondLevel = 5.688363f;
    public static float minXpointToSpawn = -8;
    public static float maxXpointToSpawn = 24;



 public static Vector2 getPoint()  {
        Vector2[] possiblePossitions = new Vector2[]
{
     new Vector2(Random.Range(minXpointToSpawn,maxXpointToSpawn), firstLevel),
    new Vector2(Random.Range(minXpointToSpawn, maxXpointToSpawn), secondLevel)
};
      Vector2 chosenPosition = possiblePossitions[Random.Range(0 , possiblePossitions.Length)];
        return chosenPosition;       
    }


    Vector2 testSpawn = new Vector2(-8, -3.311636f);

	
	void Update () {

        if (entityExists < entityQuantity)
        {
            Instantiate(entity, testSpawn, Camera.main.transform.rotation);
            entityExists++;
        }

       
		
	}
}
