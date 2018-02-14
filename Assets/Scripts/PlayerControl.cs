using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    
    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer spriteRenderer;


    public float speed = 100;
    public float jumpSpeed = 20;

    private bool canJump = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(gameObject.transform.childCount);
	}
	
	// Update is called once per frame
	void Update () {
        
        var horizontal = Input.GetAxis("Horizontal");

        anim.SetBool("walking", horizontal != 0);

        if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        body.AddForce(Vector2.right * horizontal * speed);

        if(Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            body.AddForce(Vector2.up * jumpSpeed);
        }

        anim.SetBool("onair", !canJump);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canJump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }

    public void TurnLightsOff()
    {
        transform.GetComponentInChildren<Light>().enabled = !transform.GetComponentInChildren<Light>().enabled;
    }
}
