using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Snap : MonoBehaviour
{
    [SerializeField] private Content _content;
    [SerializeField] private float _scrollingDuration;
    
    private RectTransform _rectScrollContent;
    private List<Vector2> _positionSnapContent;
    private InputSystem _input;
    private Coroutine _scrolling;
    private float _startTime;
    
    
    private void Awake()
    {
        _rectScrollContent = _content.GetComponent<RectTransform>();
        _input = new InputSystem();
    }

    void Start()
    {
        _positionSnapContent = _content.Position;
        _scrolling = null;
        _input.InputPlayer.ClickDown.performed += context =>
        {
            if (_scrolling != null)
            {
                StopCoroutine(_scrolling);
                _scrolling = StartCoroutine(Scrolling(_rectScrollContent, FindTheNearest(_positionSnapContent), _scrollingDuration));
            }
            else
            {
                _scrolling = StartCoroutine(Scrolling(_rectScrollContent, FindTheNearest(_positionSnapContent), _scrollingDuration));
            }
            
        };
    }


    private void OnEnable()
    {
        _input.Enable();
    }


    private void OnDisable()
    {
        _input.Disable();
    }
    
    private Vector2 FindTheNearest(List<Vector2> positions)
    {
        float distance = float.MaxValue;
        Vector2 nearestPostion = Vector2.zero;
        foreach (var position in positions)
        {
            float currentDistance = Mathf.Abs(position.x - _rectScrollContent.localPosition.x);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                nearestPostion = position;
            }
        }

        return nearestPostion;
    }



    private IEnumerator Scrolling(RectTransform _rectScroll, Vector2 endPositionScroll, float durationScrolling)
    {
        float startTime = Time.time;
        while (!_rectScroll.localPosition.Equals(endPositionScroll))
        {
            
            float delta = Mathf.SmoothStep(_rectScroll.localPosition.x, endPositionScroll.x,
                (Time.time - startTime)/durationScrolling);
            _rectScrollContent.localPosition = new Vector3(delta, endPositionScroll.y, 0f);
            yield return null;
        }

    }

}
