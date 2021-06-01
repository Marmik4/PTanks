using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode_Audio : MonoBehaviour
{
    public AudioSource Audio;
    public GameObject bazooka;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Audio.Play();
        }

        if (collision.collider.CompareTag("player"))
        {
            Audio.Play();
        }
    }
}
