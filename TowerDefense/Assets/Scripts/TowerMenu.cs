using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerMenu : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private Tower _tower;
    private ShoppingMenu _shoppingMenu;
    private bool _isShoppingMenuOpen;


    void Start()
    {
        _shoppingMenu = FindObjectOfType<ShoppingMenu>().GetComponent<ShoppingMenu>();
        _isShoppingMenuOpen = false;
    }

    
    
    
    
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _isShoppingMenuOpen = !_isShoppingMenuOpen;
        Debug.Log("111111");
        if (_isShoppingMenuOpen)
        {
            _shoppingMenu.Open(_tower);
        }
        else
        {
            
            _shoppingMenu.Close();
        }
    }
}
