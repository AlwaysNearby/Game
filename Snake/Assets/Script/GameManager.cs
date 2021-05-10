using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public Text appleScore;
    public Text BesScore;
    public AudioClip eatSound;
    

    private LoadMap loadMap;
    private int score = 0;
    private string Path = "";
    private int BestScore;
    private AudioSource audio;
    private GameObject snake;



    private void Awake()
    {
        if (instance == null)
            instance = this;

        loadMap = GetComponent<LoadMap>();


        InitGame();
    }



    private void Start()
    {
        snake = GameObject.Find("Snake");
        appleScore.text = "" + (0);
        BesScore.text = "Best Score: " + PlayerPrefs.GetInt("Score", 0);
        BestScore = PlayerPrefs.GetInt("Score", 0);
        audio = GetComponent<AudioSource>();
    }


    void InitGame()
    {
        loadMap.LoadTexture();
        loadMap.LoadApple();
        
    }


    public void loadFood()
    {
        loadMap.LoadApple();
    }


    public void AddScore()
    {
        score += 1;

        if(score % 10 == 0)
        {
            var newSpeed = snake.GetComponent<Snake>();
            newSpeed.IncreaseSpeed();
        }

        appleScore.text = "" + (score);
        if(score >= BestScore)
        {
            BestScore = score;
        }
        BesScore.text = "Best Score: " + (BestScore);

    }


    public void PlaySoud()
    {
        audio.PlayOneShot(eatSound);
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("Score", BestScore);
        Destroy(instance);
        SceneManager.LoadScene("MenuScene");

    }
}
