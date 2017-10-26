using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
    public float maxSpeed = 3;
    public float speed = 50f;
    public float tightspeed = .2f;
    public float runSpeed = 2f;
    public float jetPower = 5f;
    public float jumpPower = 300f;
    public float airTime = 50f;
    public float jumpFrames = 0.5f;
    private Rigidbody2D rb2d;
    public Transform playerpos;
    private SpriteRenderer sprite;
    private Vector3 movement;
    public BoxCollider2D footbox;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerpos = gameObject.GetComponent<Transform>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        footbox = gameObject.GetComponentsInChildren<BoxCollider2D>()[1];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
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
        //TightMove();

        //SpringJump();
        JetJump();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag != "Trigger")
        {
            airTime = 20f;
        }
    }

    /*private void SpringJump()
    {
        if (Input.GetButtonDown("Jump") && midair == false)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }*/

    private void JetJump()
    {
        if (Input.GetAxis("Jump") > 0 && airTime > 0)
        {
            airTime -= 1.0f;
            rb2d.velocity = new Vector2(rb2d.velocity.x, Vector2.up.y * jetPower);
        } else if (Input.GetAxis("Jump") == 0 && airTime < 20f)
        {
            airTime = 0f;
        }
    }

    private void TightMove()
    {
        float h = Input.GetAxis("Horizontal");
        movement = new Vector3(Input.GetAxis("Horizontal") * tightspeed, 0, 0);

        if(Input.GetAxis("Sprint") > 0)
        {
            playerpos.position += movement * runSpeed;
        } else
        {
            playerpos.position += movement;
        }
        
    }

    private void FloatMove()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed) * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
}
