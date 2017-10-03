using UnityEngine;
using System.Collections;

public class PupperScript : MonoBehaviour {
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 300f;
    public bool midair;
    private Rigidbody2D rb2d;
    private Animator anim;


	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Midair", midair);
        anim.SetFloat("Speed", rb2d.velocity.x);
	}
}
