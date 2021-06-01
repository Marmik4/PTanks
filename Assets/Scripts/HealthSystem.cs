using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]private HealthBar healthbar;
    private Rigidbody2D player;
    public float health = 1f;
    public GameObject pl;
    public GameObject explosion;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("bazooka"))
        {
            if (health > 0.1f)
            {
                health -= 0.15f;
                healthbar.SetSize(health);
            }

            if(health<0.4f)
            {
                healthbar.SetColor();
            }
        }
    }

    private void Update()
    {
        if(health<=0f)
        {
            Destroy(pl);
            Instantiate(explosion, player.position, Quaternion.identity);
        }
    }
}
