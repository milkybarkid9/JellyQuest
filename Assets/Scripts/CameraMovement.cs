using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    float tileWidth;
    float tileHeight;
    float rows;
    float cols;

    // Use this for initialization
    void Start () {
        tileWidth = GameObject.Find("GameManager").GetComponent<DungeonDisplay>().getTileWidth();
        tileHeight = GameObject.Find("GameManager").GetComponent<DungeonDisplay>().tileHeight;
        rows = GameObject.Find("GameManager").GetComponent<MapGenerator>().getMapRows();
        cols = GameObject.Find("GameManager").GetComponent<MapGenerator>().getMapColumns();
    }
	
	// Update is called once per frame
	void Update () {
        float yPos = GameObject.Find("Sphere").transform.position.y;
        float xPos = GameObject.Find("Sphere").transform.position.x;
        xPos = Mathf.Clamp(xPos, -10, 40*cols-30);
        gameObject.transform.position = new Vector3(xPos, yPos, -10);
    }
}
