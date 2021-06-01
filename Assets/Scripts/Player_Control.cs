using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    GameObject[] playersObjs;
    GameObject[] turretObjs;
    GameObject[] markerObjs;
    SpriteRenderer[] markerSprites;
    Transform[] players;
    Selected[] selectedComponents;
    Shoot[] shotConfirm;
    Movement[] Fuelreset;
    HealthSystem[] hs;
    public GameObject GameOverUI;
    public Text GameOver;

    public static Transform mainPlayer;
    private void Start()
    {
        playersObjs = new GameObject[GameObject.FindGameObjectsWithTag("player").Length];
        playersObjs = GameObject.FindGameObjectsWithTag("player");
        turretObjs = new GameObject[GameObject.FindGameObjectsWithTag("turret").Length];
        turretObjs = GameObject.FindGameObjectsWithTag("turret");
        markerObjs = new GameObject[GameObject.FindGameObjectsWithTag("marker").Length];
        markerObjs = GameObject.FindGameObjectsWithTag("marker");
        markerSprites = new SpriteRenderer[markerObjs.Length];
        players = new Transform[playersObjs.Length];
        selectedComponents = new Selected[playersObjs.Length];
        shotConfirm = new Shoot[turretObjs.Length];
        Fuelreset = new Movement[playersObjs.Length];
        hs = new HealthSystem[playersObjs.Length];

        for (int i=0;i<playersObjs.Length;i++)
        {
            players[i] = playersObjs[i].transform;
            selectedComponents[i] = playersObjs[i].GetComponent<Selected>();
            shotConfirm[i] = turretObjs[i].GetComponent<Shoot>();
            Fuelreset[i] = playersObjs[i].GetComponent<Movement>();
            markerSprites[i] = markerObjs[i].GetComponent<SpriteRenderer>();
            hs[i] = playersObjs[i].GetComponent<HealthSystem>();

            if (selectedComponents[i].selected)
            {
                mainPlayer = selectedComponents[i].gameObject.transform;
            }
        }
    }
    void Update()
    {
        for(int i=0;i<2;i++)
        {
            if(hs[i].health<0.1f)
            {
                if (i == 0)
                {
                    GameOverUI.SetActive(true);
                    GameOver.text = "PLAYER1 WON";   
                }
                else
                {
                    GameOverUI.SetActive(true);
                    GameOver.text = "PLAYER2 WON";
                }
            }
        }
        if (shotConfirm[0].shot)
        {
            StartCoroutine(ChangePlayer(1, 2*shotConfirm[0].time));
        }

        if (shotConfirm[1].shot)
        {
            StartCoroutine(ChangePlayer(0, 2*shotConfirm[1].time));
        }
    }

    IEnumerator ChangePlayer(int index,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        for (int i=0;i<selectedComponents.Length;i++)
        {
            if(i==index)
            {
                selectedComponents[i].selected = true;
                Fuelreset[i].MaxFuel = 1;
                mainPlayer = selectedComponents[i].gameObject.transform;
                markerSprites[i].enabled = false;
            }
            else 
            {
                selectedComponents[i].selected = false;
                shotConfirm[i].shot = false;
                markerSprites[i].enabled = true;
            }
        }
    }
}
