using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{


    public GameObject build;


    private SpriteRenderer sprite;


    private void Awake()
    {
        sprite = build.GetComponent<SpriteRenderer>();
    }






    public void ChangeColor(bool available)
    {
        if(available)
        {
            sprite.color = new Color(0, 255, 0);
        }
        else
        {
            sprite.color = new Color(255, 0, 0);
        }
    }


    public void SetDefaultColor()
    {
        sprite.color = new Color(255, 255, 255);
    }


}
