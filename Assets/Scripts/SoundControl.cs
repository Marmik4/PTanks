using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource explosionAudio;
    public AudioSource groundHit;
    Destroy_bazooka desBaz;
    GameObject[] bazooka;
    public GameObject[] turretObjs;

    bool flagExplosion = false;
    private void Update()
    {
        bazooka = new GameObject[GameObject.FindGameObjectsWithTag("bazooka").Length];
        bazooka = GameObject.FindGameObjectsWithTag("bazooka");

        if(bazooka.Length>0)
        { 
            desBaz = bazooka[0].GetComponent<Destroy_bazooka>();
            flagExplosion=true;
        }
       
        if(flagExplosion)
        {
            if (desBaz.tankDamaged)
            {
                explosionAudio.Play();
                desBaz.tankDamaged = false;
            }

            if(desBaz.groundHit)
            {
                groundHit.Play();
                desBaz.groundHit = false;
            }
        }
        
    }
}
