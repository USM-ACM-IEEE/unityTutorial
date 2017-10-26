using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnEnemyScript : MonoBehaviour {
    public float speed = 1.0f;
    private Vector3 movement;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            movement = new Vector3((collision.transform.position.x - transform.position.x) * Time.deltaTime, 0);
            transform.position += movement * speed;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            movement = new Vector3((collision.transform.position.x - transform.position.x) * Time.deltaTime, 0);
            transform.position += movement * speed;
        }
    }
}
