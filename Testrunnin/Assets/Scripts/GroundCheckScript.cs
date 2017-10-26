using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour {

    private PlayerScript player;

    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.midair = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.midair = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.midair = true;
    }
}
