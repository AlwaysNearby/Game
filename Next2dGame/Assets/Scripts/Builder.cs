using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Builder : MonoBehaviour
{

    public Tilemap baseMap;


    private Building currentBuild;
    private Building[,] buildings;



    private void Start()
    {
        buildings = new Building[baseMap.size.x + 1, baseMap.size.y + 1];
    }

    public void StartBuild(Building building)
    {
        if(currentBuild != null)
        {
            Destroy(currentBuild.gameObject);
        }

        currentBuild = Instantiate(building);
    }


    void Update()
    {
        

        if(currentBuild != null)
        {
            var posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            int x = (int)Mathf.Ceil(posMouse.x);
            int y = (int)Mathf.Ceil(posMouse.y);
            bool canBuild = true;
            currentBuild.transform.position = new Vector3(x, y, 0);



            canBuild = BuildingCheck(x, y);

            if (x <= -16 || x >= 16 || y >= 9 || y <= -9)
            {
                canBuild = false;
            }

            



            
            currentBuild.ChangeColor(canBuild);

            if (Input.GetMouseButtonDown(0) && canBuild)
            {
                buildings[(x + 16) % 33, (y + 9) % 19] = currentBuild;
                currentBuild.SetDefaultColor();
                currentBuild = null;
            }

            
        }
        
        
    }



    private bool BuildingCheck(int x, int y)
    {
        if (buildings[(x + 16) % 33, (y + 9) % 19] != null)
            return false;

        return true;
            
    }

}
