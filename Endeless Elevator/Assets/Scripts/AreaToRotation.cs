using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaToRotation : MonoBehaviour
{

    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }



    public bool СheckHitArea(Vector2 screenPosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(_rect, screenPosition, null);
    }
}
