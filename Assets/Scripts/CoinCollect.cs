using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour {

    GameObject sphere;

    // Use this for initialization
    void Start () {
        sphere = GameObject.Find("Sphere");
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.tag.Equals("Player"))
        {
            sphere.GetComponent<BallMovement>().currentScore++;
            Destroy(gameObject);
        }
    }
}
