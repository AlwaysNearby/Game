using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerSelector : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Tower _selectedTower;
    private Builder _builder;
    


    private void Start()
    {
        _builder = FindObjectOfType<Builder>().GetComponent<Builder>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        if (Balance.Instance.Cost >= _selectedTower.buildCost)
        {
            _builder.SetTowerToBuild(_selectedTower);
        }
    }
}
