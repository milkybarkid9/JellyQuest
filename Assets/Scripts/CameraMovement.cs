using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float yPos = GameObject.Find("Sphere").transform.position.y;
        float xPos = GameObject.Find("Sphere").transform.position.x;
        gameObject.transform.position = new Vector3(xPos, yPos, -10);
    }
}
