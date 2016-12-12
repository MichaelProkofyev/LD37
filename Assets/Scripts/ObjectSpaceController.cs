using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpaceController : MonoBehaviour {

    public Transform[] spawnControlPoints;

    public Vector3 RandomSpawnPoint() {
        int randomFirstPoint = Random.Range(0, spawnControlPoints.Length - 1);

        Vector3 firstPoint = spawnControlPoints[randomFirstPoint].position;
        Vector3 secondPoint = spawnControlPoints[randomFirstPoint + 1].position;

        Vector3 spawnPoint = new Vector3(Random.Range(firstPoint.x, secondPoint.x), 10f, Random.Range(firstPoint.z, secondPoint.z));

        return spawnPoint;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
