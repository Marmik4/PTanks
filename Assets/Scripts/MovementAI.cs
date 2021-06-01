using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementAI : MonoBehaviour
{
    Rigidbody2D player;
    public Vector2 velocity;
    int dist;
    float distance;
    int direction;
    float randMove;
    Vector2 initPos;
    bool selected;
    Selected sel;
    public float MaxFuel = 1;
    float time;
    public bool bodyMoved;
    public bool randDistGenerated=false;
    public float initTime;
    public GameObject turretObj;
    ShootAI hasShot;

    public Text fuel;
    public Image fuelImage;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        sel = gameObject.GetComponent<Selected>();
        hasShot = turretObj.GetComponent<ShootAI>();
        //turretObj = GameObject.Find("turret");
        initPos = player.position;
        bodyMoved = false;
        randDistGenerated = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Barrier"))
        {
            randDistGenerated = false;
            player.velocity = Vector3.zero;
            initPos = player.position;
            //player.angularVelocity = Vector3.zero;
            bodyMoved = true;
        }

        if (collision.collider.CompareTag("player"))
        {
            randDistGenerated = false;
            direction = 1;
            player.AddForce(direction * velocity * Time.deltaTime, ForceMode2D.Impulse);
            //player.velocity = Vector3.zero;
            initPos = player.position;
            if((int)Vector3.Distance(initPos, player.position)==5)
            {
                player.velocity = Vector3.zero;
                initPos = player.position;
            }
            //player.angularVelocity = Vector3.zero;
            bodyMoved = true;
        }
    }
    void Update()
    {
        selected = sel.selected;
        if (selected)
        {
            if (hasShot.shot == false)
            {
                if (bodyMoved == false)
                {
                    if (MaxFuel > 0)
                    {
                        if (randDistGenerated == false)
                        {
                            initTime = Time.time;
                            randMove = Random.Range(0, 7);
                            if (Random.value > 0.5)
                            {
                                direction = 1;
                            }
                            else
                            {
                                direction = -1;
                            }
                            randDistGenerated = true;
                        }

                        player.AddForce(direction * velocity * Time.deltaTime, ForceMode2D.Impulse);
                        dist = (int)Vector3.Distance(initPos, player.position);
                        distance = Vector3.Distance(initPos, player.position);
                        //Debug.Log(distance);
                        time = (dist / Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2))) / (player.mass / 5);
                        //Debug.Log(dist);

                        if (MaxFuel < 0.1f || dist == randMove)
                        {
                            randDistGenerated = false;
                            player.velocity = Vector3.zero;
                            initPos = player.position;
                            //player.angularVelocity = Vector3.zero;
                            bodyMoved = true;
                        }

                        if(Time.time - initTime > 7)
                        {
                            randDistGenerated = false;
                            player.velocity = Vector3.zero;
                            initPos = player.position;
                            //player.angularVelocity = Vector3.zero;
                            bodyMoved = true;
                        }

                        //Debug.Log(time);
                        UpdateUI();
                    }
                    else
                    {
                        bodyMoved = true;
                    }
                    //hasShot.shot = false;
                }
            }
        }
           
    }

    void UpdateUI()
    {
        MaxFuel = MaxFuel - time;
        fuelImage.fillAmount = MaxFuel;
        //Debug.Log(MaxFuel);
    }
}
