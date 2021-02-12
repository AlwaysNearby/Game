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
        for(var i = -17; i < 17; i++){
            for(var j = -7; j < 8; j++)
            {

                var newTile = Instantiate(_tileObject, new Vector3(i, j, 0), Quaternion.identity);
                newTile.transform.SetParent(board.transform);
                if((i >= -14 && i <= -9) || (i >= 10 && i <= 14))
                {
                    if(j % 2 == 0)
                    {
                        if(Random.RandomRange(5, 9) == 6)
                        {
                         var _env =  Instantiate(_environments[Random.RandomRange(0, _environments.Length - 1)], new Vector3(i, j, 0), Quaternion.identity);
                         _env.transform.SetParent(_parantEnvironments.transform);
                        }
                    }
                }

            }
        }
    }
}
