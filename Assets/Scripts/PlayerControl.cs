using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    
    private Rigidbody2D body;
    private Animator anim;


    public float speed = 100;
    public float jumpSpeed = 20;

    private bool canJump = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        var horizontal = Input.GetAxis("Horizontal");

        anim.SetBool("walking", horizontal != 0);

        body.AddForce(Vector2.right * horizontal * speed);

        if(Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            body.AddForce(Vector2.up * jumpSpeed);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canJump = true;
    }
}
