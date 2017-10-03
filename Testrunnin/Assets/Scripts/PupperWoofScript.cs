using UnityEngine;
using System.Collections;

public class PupperWoofScript : MonoBehaviour {

    private AudioSource sound;

    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        sound.Play();
    }
}
