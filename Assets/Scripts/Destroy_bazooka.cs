using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_bazooka : MonoBehaviour
{
    public GameObject impact_ex;
    public GameObject explosion;
    Rigidbody2D bazooka;
    public bool tankDamaged = false;
    public bool groundHit = false;
    private shake shakescreen;

    private void Start()
    {
        bazooka = GetComponent<Rigidbody2D>();
        shakescreen = GameObject.FindGameObjectWithTag("shake").GetComponent<shake>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            groundHit = true;
            Destroy(gameObject);          
            Instantiate(impact_ex, bazooka.position, Quaternion.identity);
        }

        if (collision.collider.CompareTag("player"))
        {
            shakescreen.collideShake();
            tankDamaged = true;
            Destroy(gameObject);
            Instantiate(explosion, bazooka.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 10f);
    }
}
