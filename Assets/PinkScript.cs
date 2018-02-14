using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("walking", Input.GetKey("v"));
	}
}
