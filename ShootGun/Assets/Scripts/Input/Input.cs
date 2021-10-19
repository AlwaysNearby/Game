using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Input : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public event Action OnEnable;
    public event Action OnDisable;

    private ActivatorModeAttack _activator;
    private Vector2Int _scrollDirection;
    private Vector2 _pressPosition;
    private bool _isActiveInput = false;

    public Vector2Int ScrollDirection => _scrollDirection;
    public bool IsActiveAttack => _activator.IsActive;
    public Vector2 PressPosition
    {
        get
        {
            return _pressPosition;
        }
    }

    private void Awake()
    {
        _activator = GetComponentInChildren<ActivatorModeAttack>();
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


        OnEnable?.Invoke();
    }

    public void Disable()
    {
        _isActiveInput = false;

        OnDisable?.Invoke();
    }
}
