using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Transform _prebafPlayer;
    public GameObject[] _lifes;
    public Text Score;

    
    private SpawnMeteor spawnmeteor;
    private SpawnBonus spawnBonus;
    private HpBar _hp;
    private int _countLife = 2;

    private void Awake()
    {
        if (instance == null)
            instance = this;


        spawnmeteor = GetComponent<SpawnMeteor>();
        spawnBonus = GetComponent<SpawnBonus>();
        _hp = GetComponent<HpBar>();
        _hp.BarUpdate(0f, 1f);
        _hp.BarUpdate(100f);
        Score.text = "0";


    }

    private void Start()
    {
        StartCoroutine(spawnmeteor.spawnMeteor());
        StartCoroutine(spawnBonus.NewBonus());
    }


    public void UpdateHealth(float health)
    {
        _hp.BarUpdate(health);
    }

    public void UpdateShield(float health, float max)
    {
        _hp.BarUpdate(health, max);
    }

    public void UpdateGame()
    {
        if(_countLife <= 0)
        {
            GameOver();
        }
        else
        {
            var player = Instantiate(_prebafPlayer, new Vector3(0f, 0f, 0f), Quaternion.identity);
            var hp = player.GetComponent<Health>();
            var _bar = GetComponent<HpBar>();
            var _allMeteors = GameObject.FindGameObjectsWithTag("Meteor");
            for(var i = 0; i < _allMeteors.Length; i++)
            {
                Destroy(_allMeteors[i]);
            }
            var anim = _lifes[_countLife - 1].GetComponent<Animator>();
            anim.SetBool("Die", true);
            _bar.BarUpdate(hp.GetHealth());


        }
    }


    public void DeleteLife()
    {
        _lifes[_countLife - 1].SetActive(false);
        _countLife--;
    }

    public void UpdateUi()
    {
        var currentScore = int.Parse(Score.text);
        currentScore++;
        Score.text = "" + currentScore; 
    }

    private void GameOver()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }


}
