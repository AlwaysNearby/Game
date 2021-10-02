using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScroll : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector2Int _direction;
    private bool _isActiveInput = false;

    public Vector2Int Direction => _direction;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isActiveInput)
        {

            int deltaX = Mathf.Clamp((int) eventData.delta.x, -1, 1);
            int deltaY = Mathf.Clamp((int) eventData.delta.y, -1, 1);

            _direction = new Vector2Int(deltaX, deltaY);
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void Enable()
    {
        _isActiveInput = true;
        _direction = Vector2Int.zero;
    }

    public void Disable()
    {
        _isActiveInput = false;
    }

}
