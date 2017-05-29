using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour {
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private  float animSpeed;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = animSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
