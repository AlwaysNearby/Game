using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{

    [SerializeField] private GameObject Ground;
    [SerializeField] private GameObject Earth;
    [SerializeField] private GameObject Board;
    [SerializeField] private GameObject Apple;

    private List<GameObject> _board;


    void Start()
    {
        LoadTexture();
        LoadApple();

    }
    public void LoadTexture()
    {

        for (int i = -6; i < 7; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                var currentTexture = Earth;
                if (i == -6 || i == 6 || j == -5 || j == 5)
                {
                    currentTexture = Ground;

                }

                Instantiate(currentTexture, new Vector3(i, j, currentTexture.transform.position.z), Quaternion.identity, Board.transform);



            }
        }

    }
    public void LoadApple()
    {
        int x = Random.Range(-4, 6);
        int y = Random.Range(-4, 5);
        Instantiate(Apple, new Vector3(x, y, 0), Quaternion.identity);

    }
}
