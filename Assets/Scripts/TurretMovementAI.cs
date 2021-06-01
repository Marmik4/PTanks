using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovementAI : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject body;
    public GameObject Opponent;
    //public float u = 5f;
    public float v;
    public Vector2 velocity;
    //Vector2 OpponentPos;
    float Range;
    //ShootAI Velocity;
    Selected select;
    bool selected;
    public float angle;
    public bool TurretMoved=false;
    MovementAI moveConfirmed;
    ShootAI hasShot;
    float g = 9.8f;

    private void Start()
    {
        select = body.GetComponent<Selected>();
        moveConfirmed = body.GetComponent<MovementAI>();
        hasShot = gameObject.GetComponent<ShootAI>();
        TurretMoved = false;
        //Velocity = body.GetComponent<ShootAI>();
    }
    void Update()
    {
        selected = select.selected;
        //if (moveConfirmed.bodyMoved)
        {
            if (selected)
            {
                if (moveConfirmed.bodyMoved)
                {
                    if (TurretMoved == false)
                    {
                        if (hasShot.shot == false)
                        {
                            //if (moveConfirmed.bodyMoved)
                            {
                                Range = Vector2.Distance(body.transform.position, Opponent.transform.position);
                                //StartCoroutine(turretMovement(5));
                                turretMovement();
                                TurretMoved = true;
                                //hasShot.shot = false;
                            }
                        }
                    }
                }
            }
        }
    }

    void turretMovement()
    {
        v = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2));
        //OpponentPos = Opponent.transform.position;
        //Debug.Log(Range);
        angle = 180-(float)0.5 * Mathf.Asin((g * Range) / Mathf.Pow(v, 2)) * Mathf.Rad2Deg*100;
        //Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * speed);
        //yield return new WaitForSeconds(delay);
    }
}
