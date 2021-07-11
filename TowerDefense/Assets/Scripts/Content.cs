using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Content : MonoBehaviour
{

    [SerializeField] private Stage _stage;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _offsetX;

    private List<Vector2> _position;
    

    public List<Vector2> Position
    {
        get => _position;
        private set { ; }
    }


    private void Awake()
    {
        _position = new List<Vector2>();
    }

    void Start()
    {
        Create(_stage, _sprites.Length);

    }
    

    private void Create(Stage stage, int count)
    {
        Vector2 lastPosition = Vector2.zero;
        for (var i = 0; i < count; i++)
        {
            var currentStage = Instantiate(stage, transform, false);
            currentStage.GetComponent<Image>().sprite = _sprites[i];
            var rectTransform = currentStage.GetComponent<RectTransform>();
            if (i == 0)
            {
                _position.Add(rectTransform.localPosition);
                continue;
            }
            var nextPosition = rectTransform.rect.width + lastPosition.x + _offsetX;
            rectTransform.localPosition = new Vector3(nextPosition, 0f, 0f);
            lastPosition = new Vector2(nextPosition,0);
            _position.Add(-rectTransform.localPosition);

        }
    }
}
