using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaLookAt : MonoBehaviour
{
    Rigidbody2D bazooka;

    private void Start()
    {
        bazooka = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 dis = bazooka.velocity;
        float theta = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        bazooka.transform.rotation = Quaternion.AngleAxis(theta, Vector3.forward);
    }
}
