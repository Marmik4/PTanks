using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private Transform SpriteBar;
    void Start()
    {
        bar = transform.Find("Bar");
        SpriteBar = bar.Find("BarSprite");
    }

   public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor()
    {
        SpriteBar.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
