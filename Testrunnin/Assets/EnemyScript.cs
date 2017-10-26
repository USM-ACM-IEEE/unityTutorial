using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public Collider2D aggrozone;
    public float speed = 1.0f;
    private Vector3 movement;


	// Use this for initialization
	void Start () {
        aggrozone = gameObject.GetComponentsInChildren<Collider2D>()[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            movement = new Vector3((collision.transform.position.x - transform.position.x) * Time.deltaTime , 0);
            transform.position += movement * speed;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Debug.Log(movement);
            movement = new Vector3((collision.transform.position.x - transform.position.x) * Time.deltaTime, 0);
            transform.position += movement * speed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
