using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGeneration : MonoBehaviour {

    private Vector3 downPos, upPos, capsulePos;

    [SerializeField]
    GameObject capsule;

    CapsuleCollider capsuleCollider;

    float distance;
    float angle;
    float range = 0.1f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            downPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);            
            downPos = Camera.main.ScreenToWorldPoint(downPos);
            Debug.Log("mouse downpos " + downPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            upPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //get pos of button up
            upPos = Camera.main.ScreenToWorldPoint(upPos); //convert from camera to world position
            Debug.Log("mouse uppos " + upPos);
            capsulePos = (downPos + upPos) * 0.5f; //find midpoint
            capsulePos.z = 0; 
            upPos = new Vector3(upPos.x, upPos.y, 0);
            downPos = new Vector3(downPos.x, downPos.y, 0);

            capsule.GetComponent<RenderLine>().Initialise(downPos, upPos);
            angle = Mathf.Atan((upPos.y - downPos.y) / (upPos.x - downPos.x)); //Tan(angle) = opposite / adjacent;
            angle = angle * 180/3.14159f; //convert to degrees
            Debug.Log("angle " + angle);
            Instantiate(capsule, capsulePos, Quaternion.AngleAxis(angle, Vector3.forward)); 
        }

        if (Input.GetMouseButton(0))
        {
            distance = Vector3.Distance(downPos, upPos);            
        }
	}
}
