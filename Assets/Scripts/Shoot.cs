using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float time;
    public float u = 5f;
    public float g = 9.8f;
    public float offsetx=5f;
    public float offsety=12f;
    Vector2 velocity;
    Object bz;
    public Transform shootpoint;
    public GameObject MuzzleEffect;
    public GameObject body;
    Selected select;
    bool selected;
    public bool shot;
    turretmovement tm;
    public Camera main;
    //loadCameraZoom ld;
    private shake shakescreen;


    void Start()
    {
        bz = Resources.Load("bazooka");
        select = body.GetComponent<Selected>();
        shot = false;
        tm = GetComponent<turretmovement>();
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
                if (shot == false)
                {
                    if (Input.GetKeyDown("f"))
                    {
                        shoot();
                        shakescreen.camShake();
                        shot = true;
                    }
                }
            }
        }
    }
    void shoot()
    {
        GameObject bazooka = (GameObject)Instantiate(bz, shootpoint.position, shootpoint.rotation);
        time =  (2 * u * Mathf.Sin(tm.angle/Mathf.Rad2Deg)) / g;
        velocity.x = u * Mathf.Cos(tm.angle / Mathf.Rad2Deg);
        if(velocity.x>0)
            velocity.x = u * Mathf.Cos(tm.angle / Mathf.Rad2Deg)+ offsetx;
        else
            velocity.x = u * Mathf.Cos(tm.angle / Mathf.Rad2Deg)- offsetx;
        velocity.y = (u * Mathf.Sin(tm.angle / Mathf.Rad2Deg)) + (g * time)-offsety;
        bazooka.GetComponent<Rigidbody2D>().velocity = (velocity);
        Instantiate(MuzzleEffect, shootpoint.position, shootpoint.rotation);
    }
}
