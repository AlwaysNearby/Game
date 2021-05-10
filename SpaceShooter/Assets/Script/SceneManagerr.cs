using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerr : MonoBehaviour
{


    public void LoadMainScene()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("MainScene");

    }


    public void ExitOnGame()
    {
        Application.Quit();
    }

}
