using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Muzzle : MonoBehaviour
{
    private void FixedUpdate()
    {
        Destroy(gameObject, 0.60f);
    }
}
