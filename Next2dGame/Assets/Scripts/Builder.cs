using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Builder : MonoBehaviour
{





    private Build _currentBuild;
    private Build[,] map;
    private bool[,] _gridBuild;


    private int _sizeMapY;
    private int _sizeMapX;

    [SerializeField]
    private Tilemap _baseMap;
    [SerializeField]
    private Build _mainBuild;
    



    private void Start()
    {
        _sizeMapX = _baseMap.size.x;
        _sizeMapY = _baseMap.size.y;
        map = new Build[_sizeMapY, _sizeMapX];
        _gridBuild = new bool[_sizeMapY, _sizeMapX];
        GridFilling(new Vector2Int((int)_mainBuild.transform.position.x + _sizeMapX / 2, (int)_mainBuild.transform.position.y + _sizeMapY / 2));
        map[(int)_mainBuild.transform.position.y + _sizeMapY / 2, (int)_mainBuild.transform.position.x + _sizeMapX / 2] = _mainBuild;
        
    }


    public void StartBuild(Build build)
    {
        if (_currentBuild != null)
        {
            Destroy(_currentBuild.gameObject);
        }


        _currentBuild = Instantiate(build);
        StartCoroutine(Development());

    }

    public IEnumerator Development()
    {
        yield return new WaitForSeconds(0.1f);

        while(true)
        {
            var posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _currentBuild.transform.position = new Vector3((int)posMouse.x, (int)posMouse.y, 0);

            bool available = CheckingThePossibilityOfBuilding(posMouse);

            if(available)
            {
                _currentBuild.ShowColoFromPlace(new Color(0, 255, 0));
            }
            else
            {
                _currentBuild.ShowColoFromPlace(new Color(255, 0, 0));
            }

            if(Input.GetKeyDown(KeyCode.Mouse0) && available)
            {

                map[(int)posMouse.y + _sizeMapY / 2, (int)posMouse.x + _sizeMapX / 2] = _currentBuild;
                GridFilling(new Vector2Int((int)posMouse.x + _sizeMapX / 2, (int)posMouse.y + _sizeMapY / 2));
                _currentBuild.ShowColoFromPlace(new Color(255, 255, 255));
                _currentBuild = null;
                break;
            }

            yield return null;
        }
        
    }





    private bool CheckingThePossibilityOfBuilding(Vector2 posBuild)
    {
        var x = (int)posBuild.x;
        var y = (int)posBuild.y;

        if(x >= _sizeMapX/2 || x <= -_sizeMapX/2 || y <= -_sizeMapY/2 || y >= _sizeMapY/2)
        {
            return false;
        }

        if(map[y + _sizeMapY / 2, x + _sizeMapX / 2] != null)
        {
            return false;
        }
        if(!_gridBuild[y + _sizeMapY / 2, x + _sizeMapX / 2])
        {
            return false;
        }
 


        return true;

    }



    private void GridFilling(Vector2Int posBuild)
    {
        _gridBuild[posBuild.y, posBuild.x] = false;
        for(var x = 0; x < _sizeMapX; x++)
        {
            for(var y = 0; y < _sizeMapY; y++)
            {
                if((Mathf.Abs(posBuild.x - x) + Mathf.Abs(posBuild.y -y) == 1) && map[y, x] == null)
                {
                    _gridBuild[y, x] = true;
                }
            }
        }
    }

}
