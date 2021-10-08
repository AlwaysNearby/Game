using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2Int _scrollDirection;
    private Vector2 _pressPosition;
    private bool _isActiveInput = false;


    public Vector2Int ScrollDirection => _scrollDirection;
    public Vector2 PressPosition
    {
        get
        {
            return _pressPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isActiveInput)
        {
            _pressPosition = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressPosition = Vector2.zero;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isActiveInput)
        {
            int deltaX = Mathf.Clamp((int)eventData.delta.x, -1, 1);
            var scrollDirection = new Vector2Int(deltaX, 0);
            _scrollDirection = scrollDirection;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _pressPosition = eventData.position;
    }

    public void Enable()
    {
        _isActiveInput = true;
        _scrollDirection = Vector2Int.zero;
    }

    public void Disable()
    {
        _isActiveInput = false;
    }
}
