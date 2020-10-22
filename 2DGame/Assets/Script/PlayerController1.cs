using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    private SpriteRenderer _render;


    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        _render.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }


    void Update()
    {
        
    }
}
