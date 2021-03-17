using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;

    [SerializeField] private Text _score;
    private int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        score = 0;
    }


    private void Start()
    {
        UpdateUiScore();
    }


    public void UpdateUiScore()
    {
        var str = "Score: " + score.ToString();
        _score.text = str;
    }


    public void IncreaseScore()
    {
        score++;
    }


    
    
}
