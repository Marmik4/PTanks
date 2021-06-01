using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIPlayer_Control : MonoBehaviour
{
    GameObject[] playersObjs;
    GameObject[] turretObjs;
    GameObject[] markerObjs;
    SpriteRenderer[] markerSprites;
    Transform[] players;
    Selected[] selectedComponents;
    Shoot shotConfirm;
    ShootAI shotConfirmAI;
    Movement Fuelreset;
    MovementAI FuelresetAI;
    MovementAI stopRandDist;
    TurretMovementAI tm;
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
        hs = new HealthSystem[playersObjs.Length];

        for (int i = 0; i < playersObjs.Length; i++)
        {
            players[i] = playersObjs[i].transform;
            selectedComponents[i] = playersObjs[i].GetComponent<Selected>();
            //Fuelreset[i] = playersObjs[i].GetComponent<Movement>();
            markerSprites[i] = markerObjs[i].GetComponent<SpriteRenderer>();
            hs[i] = playersObjs[i].GetComponent<HealthSystem>();
            if (i == 0)
            {
                shotConfirmAI = turretObjs[i].GetComponent<ShootAI>();
                FuelresetAI = playersObjs[i].GetComponent<MovementAI>();
                stopRandDist = playersObjs[i].GetComponent<MovementAI>();
                tm = turretObjs[i].GetComponent<TurretMovementAI>();
            }
            if (i==1)
            {
                shotConfirm = turretObjs[i].GetComponent<Shoot>();
                Fuelreset = playersObjs[i].GetComponent<Movement>();
            }

            if (selectedComponents[i].selected)
            {
                mainPlayer = selectedComponents[i].gameObject.transform;
            }
        }
    }
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            if (hs[i].health < 0.1f)
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
        if (shotConfirmAI.shot)
        {
            StartCoroutine(ChangePlayer(1, 2 * shotConfirmAI.time));
        }

        if (shotConfirm.shot)
        {
            StartCoroutine(ChangePlayer(0, 2 * shotConfirm.time));
        }
    }

    IEnumerator ChangePlayer(int index, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        for (int i = 0; i < selectedComponents.Length; i++)
        {
            if (i == index)
            {
                selectedComponents[i].selected = true;

                if (i == 0)
                {
                    FuelresetAI.MaxFuel = 1;
                    //stopRandDist.randDistGenerated = false;
                    stopRandDist.bodyMoved = false;
                    tm.TurretMoved = false;
                }
                if (i == 1)
                    Fuelreset.MaxFuel = 1;

                mainPlayer = selectedComponents[i].gameObject.transform;
                markerSprites[i].enabled = false;
            }
            else
            {
                selectedComponents[i].selected = false;
                if (i == 0)
                    shotConfirmAI.shot = false;
                if(i==1)
                    shotConfirm.shot = false;
                markerSprites[i].enabled = true;
            }
        }
    }
}
