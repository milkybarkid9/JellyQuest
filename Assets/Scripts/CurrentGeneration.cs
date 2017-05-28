using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGeneration : MonoBehaviour {

    private Vector3 lastPos, currentPos;
    private Vector4 movement; //x, y, direction, force
    

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (currentPos != null)
                lastPos = currentPos;

            currentPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
	}
}
