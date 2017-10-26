using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnPlayerScript : MonoBehaviour {
    public float speed = 50f;
    public float maxSpeed = 3f;
    public float runSpeed = 2f;
    public float jumpPower = 300f;
    public Transform playerpos;
    private Vector3 movement;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    public bool midair = false;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerpos = gameObject.GetComponent<Transform>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") < -0.1f) {
            sprite.flipX = false;
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            sprite.flipX = true;
        }
	}

    private void FixedUpdate()
    {
        FloatMove();

        SpringJump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Trigger")
        {
            Debug.Log(collision.tag);
            midair = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Trigger")
        {
            Debug.Log(collision.tag);
            midair = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        midair = true;
    }

    private void FloatMove()
    {
        float h = Input.GetAxis("Horizontal");
        if(Input.GetAxis("Sprint") > 0)
        {
            rb2d.AddForce((Vector2.right * speed) * h * runSpeed);
        } else
        {
            rb2d.AddForce((Vector2.right * speed) * h);
        }

        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    private void SpringJump()
    {
        if (Input.GetAxis("Jump") > 0 && midair == false)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }
}
