using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField]
    public float ballVelocity = 100;
    Rigidbody2D rb;
    bool mapOpen = false;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(-10, -10, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0 && mapOpen == false)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, ballVelocity, 0));
        }
        if (Input.GetAxis("Vertical") < 0 && mapOpen == false)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, -ballVelocity, 0));
        }
        if (Input.GetAxis("Horizontal") > 0 && mapOpen == false)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballVelocity, 0, 0));
        }
        if (Input.GetAxis("Horizontal") < 0 && mapOpen == false)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(-ballVelocity, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 30;
            mapOpen = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 5;
            mapOpen = false;
        }
    }
}
