using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretmovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject body;
    Selected select;
    bool selected;
    public float angle;

    private void Start()
    {
        select = body.GetComponent<Selected>();
    }
    void Update()
    {
        selected = select.selected;
        if(selected)
        {
            if (Input.GetMouseButton(0))
            {
                var pos = Camera.main.WorldToScreenPoint(transform.position);
                var dir = Input.mousePosition - pos;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * speed);
            }
        }    
    }
}
