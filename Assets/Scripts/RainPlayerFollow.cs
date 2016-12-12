using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainPlayerFollow : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    float rate = 0.2f;
    float lastUpdate = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void LateUpdate()
    {
        lastUpdate += Time.deltaTime;
        if(lastUpdate > rate)
        {
            Vector3 newPos = player.transform.position + offset;
            transform.position = newPos;
            lastUpdate = 0f;
        }

    }
}
