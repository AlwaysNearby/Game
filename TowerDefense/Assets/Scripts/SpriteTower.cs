using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTower : MonoBehaviour
{
    
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    
    
    public void SetNewSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
    

}
