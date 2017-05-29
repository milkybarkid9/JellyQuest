using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGeneration : MonoBehaviour {

    private Vector3 lastPos, currentPos;
    private Vector4[] movement; //x, y, direction, force
    int frameCount = 0;
    GameObject ball = GameObject.Find("Sphere");
    float range = 0.1f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (frameCount <= 600)
            frameCount = 0;

        if (Input.GetMouseButton(0))
        {
            lastPos = currentPos;
            currentPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

            float distance = Vector3.Distance(lastPos, currentPos);
            float time = Time.deltaTime;
            float speed = distance / time;

            float direction = Vector3.Angle(lastPos, currentPos);
            movement[frameCount] = new Vector4(currentPos.x, currentPos.y, direction, speed);
        }

        //if((ball.transform.position.x - center_x) ^ 2 + (ball.transform.position.y - center_y) ^ 2 < range ^ 2)

        frameCount++;
	}
}
