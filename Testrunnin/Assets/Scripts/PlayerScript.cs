using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 300f;
    public bool midair;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource sound;
    private SpriteRenderer sprite;
    public Transform playerpos;

	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        playerpos = gameObject.GetComponent<Transform>();
	}
	
	void Update () {
        anim.SetBool("Midair", midair);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            sprite.flipX = false;
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            sprite.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && midair == false)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
            sound.Play();
        }
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce((Vector2.right * speed) * h);

        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
}
