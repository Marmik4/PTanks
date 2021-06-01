using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody2D player;
    public Vector2 velocity;
    float dist;
    Vector2 initPos;
    bool selected;
    Selected sel;
    public float MaxFuel=1;
    float time;

    public Text fuel;
    public Image fuelImage;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        sel = gameObject.GetComponent<Selected>();
        initPos = player.position;
    }
    void Update()
    {
        selected = sel.selected;
        if (selected)
        {
            if(MaxFuel>0)
            {
                if (Input.GetKey("a"))
                {
                    //velocity.y = -velocity.y;
                    if(velocity.x>0)
                        velocity.x = -velocity.x;
                    player.AddForce(velocity * Time.deltaTime, ForceMode2D.Impulse);
                    dist = Vector3.Distance(player.position, initPos);
                    //time = (dist / Mathf.Sqrt(Mathf.Pow(velocity.x,2)+ Mathf.Pow(velocity.y, 2))) /(player.mass/5);
                    //Debug.Log(velocity);
                    UpdateUI();
                }
                if (Input.GetKeyUp("a"))
                {
                    initPos = player.position;
                }

                if (Input.GetKey("d"))
                {
                    if(velocity.x<0)
                        velocity.x = -velocity.x;
                    player.AddForce(velocity * Time.deltaTime, ForceMode2D.Impulse);
                    dist = Vector3.Distance(player.position, initPos);
                    //time = (dist / Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2))) / (player.mass / 5);
                    //Debug.Log(velocity);
                    UpdateUI();
                }
                if (Input.GetKeyUp("d"))
                {
                    initPos = player.position;
                }
            }
            else
            {
                player.velocity = new Vector2(0f, 0f);
            }
        }
    }

    void UpdateUI()
    {
        MaxFuel = MaxFuel - dist/1000;
        fuelImage.fillAmount =MaxFuel;
        //Debug.Log(MaxFuel);
    }
}
