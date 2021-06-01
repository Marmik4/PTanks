using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Explosion : MonoBehaviour
{
    private void FixedUpdate()
    {
        Destroy(gameObject,0.8f);    
    }
}
