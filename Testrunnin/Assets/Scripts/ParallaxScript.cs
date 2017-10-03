using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {

    private PlayerScript player;
    private SpriteRenderer sprite;
    private Transform pos;
    public float speed = 0.5f;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<PlayerScript>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        pos = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        pos.position = new Vector3(player.playerpos.position.x * speed, pos.position.y, pos.position.z);
	}
}
