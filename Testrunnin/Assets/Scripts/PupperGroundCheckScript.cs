using UnityEngine;
using System.Collections;

public class PupperGroundCheckScript : MonoBehaviour {

    private PupperScript pupper;

    void Start()
    {
        pupper = gameObject.GetComponentInParent<PupperScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        pupper.midair = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        pupper.midair = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        pupper.midair = true;
    }
}
