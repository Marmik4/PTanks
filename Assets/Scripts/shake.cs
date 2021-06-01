using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    public Animator camAnim;

    public void camShake()
    {
        camAnim.SetTrigger("hasShot");
    }

    public void collideShake()
    {
        camAnim.SetTrigger("hasCollided");
    }
}
