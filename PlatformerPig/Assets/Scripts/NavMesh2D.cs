using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NavMesh2D : MonoBehaviour
{

    private int[,] mapForNavigation;
    private Vector2Int sizeMap;
    private int offsetY, offsetX;

    void Start()
    {
        mapForNavigation = Map.map.GetMapMesh();
        sizeMap = Map.map.GetSizeMap();
        offsetX = (int)(sizeMap.x / 2);
        offsetY = (int)(sizeMap.y / 2);
    }

}
