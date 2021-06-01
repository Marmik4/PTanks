using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public float time;
    public float u = 5f;
    public float g = 9.8f;
    public float offsetx = 10.5f;
    public float offsety = 2f;
    
    Vector2 velocity;
    Object bz;
    public Transform shootpoint;
    public GameObject MuzzleEffect;
    public GameObject body;
    //public GameObject Opponent;
    Selected select;
    bool selected;
    public bool shot;
    TurretMovementAI tm;
    public Camera main;
    //loadCameraZoom ld;
    private shake shakescreen;
    MovementAI moveConfirmed;


    void Start()
    {
        bz = Resources.Load("bazooka");
        select = body.GetComponent<Selected>();
        shot = false;
        tm = GetComponent<TurretMovementAI>();
        moveConfirmed = body.GetComponent<MovementAI>();
        //ld = main.GetComponent<loadCameraZoom>();
        shakescreen = GameObject.FindGameObjectWithTag("shake").GetComponent<shake>();
    }

    void Update()
    {
        selected = select.selected;
        //if(ld.cameraLd)
        {
            if (selected)
            {
                if (moveConfirmed.bodyMoved)
                {
                    if (tm.TurretMoved)
                    {
                        if (shot == false)
                        {
                            //if(tm.TurretMoved)
                            {
                                shoot();
                                shakescreen.camShake();
                                shot = true;
                            }
                            //Debug.Log("shot");
                        }
                    }
                }
            }
        }
    }
    void shoot()
    {
        //tm.TurretMoved = false;
        //moveConfirmed.bodyMoved = false;
        GameObject bazooka = (GameObject)Instantiate(bz, shootpoint.position, shootpoint.rotation);
        time = (2 * u * Mathf.Sin((tm.angle)/ Mathf.Rad2Deg)) / g;
        velocity.x = u * Mathf.Cos((tm.angle) / Mathf.Rad2Deg);
        offsetx = Random.Range(10.2f, 12f);
        offsety = Random.Range(1f, 3f);
        if (velocity.x > 0)
            velocity.x = u * Mathf.Cos((tm.angle) / Mathf.Rad2Deg) + offsetx;
        else
            velocity.x = u * Mathf.Cos((tm.angle) / Mathf.Rad2Deg) - offsetx;
        velocity.y = (u * Mathf.Sin((tm.angle) / Mathf.Rad2Deg)) + (g * time) + offsety;
        //Debug.Log(velocity);
        bazooka.GetComponent<Rigidbody2D>().velocity = (velocity);
        Instantiate(MuzzleEffect, shootpoint.position, shootpoint.rotation);
    }
}
