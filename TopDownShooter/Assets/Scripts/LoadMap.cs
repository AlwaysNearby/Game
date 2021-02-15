using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
    
    public GameObject board;
    public GameObject[] _environments;

    public GameObject _parantEnvironments;

    [SerializeField] private GameObject _tileObject;

    void Start()
    {
        LoadBoard();
    }

    void LoadBoard()
    {
        for(var i = -17; i < 18; i++){
            for(var j = -17; j < 17; j++)
            {

                var newTile = Instantiate(_tileObject, new Vector3(i, j, 0), Quaternion.identity);
                newTile.transform.SetParent(board.transform);

            }
        }
    }
}
