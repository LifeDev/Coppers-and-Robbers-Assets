using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour {

    int entityExists = 0;
    public float entityQuantity = 5;

    public GameObject entity;


    private float[,] points = new float[,] { 
        {-5,-3},
        {20,-3},
        {40,-3}
};

    private float[] pointsToSpawn = new float[] {-5,20,40};
	
	void Update () {

        if (entityExists < entityQuantity)
        {
            Vector3 Pos = new Vector3(pointsToSpawn[Random.Range(0,2)] , -3 , 0);
            Instantiate(entity , Pos , Camera.main.transform.rotation);
  
            entityExists++;
        }

       
		
	}
}
