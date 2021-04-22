using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{

    [SerializeField] private Tilemap _wall;

    private Vector2Int _sizeMap;
    private int[,] _marks;


    public static Map map;





    public int[,] GetMapMesh()
    {
        return _marks;
    }


    public Vector2Int GetSizeMap()
    {
        return _sizeMap;
    }





    private void Awake()
    {
        if(map == null)
        {
            map = this;
        }

    }

    private void Start()
    {
        _sizeMap = new Vector2Int(_wall.size.x - 2, _wall.size.y-2);
        _marks = new int[_sizeMap.x, _sizeMap.y];

        PutMarks(_marks, _sizeMap.x, _sizeMap.y);
    }

    

    private void PutMarks(int[,] map, int sizeX, int sizeY)
    {

       

    }



    



}
