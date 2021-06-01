using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_ImpactE : MonoBehaviour
{
    private void FixedUpdate()
    {
        Destroy(gameObject,0.7f);
    }
}
